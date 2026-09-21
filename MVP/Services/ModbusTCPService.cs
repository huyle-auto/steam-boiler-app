using Microsoft.IdentityModel.Tokens;
using NModbus;
using NModbus.Device;
using SteamBoilerApp.HWConfig;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public class ModbusTCPService : IModbusTCPService
    {
        private readonly System.Threading.Timer _heartbeatTimer;

        private TcpClient? _tcpClient;
        private IModbusMaster? _master;

        private string _ipAddress = "192.168.60.170";
        private int _port = 502;
        private int _unitId = 1;
        private readonly int POLL_CYCLE_MS = 1000;
        private readonly int RECONNECT_ATTEMPT = 10;
        private readonly int RECONNECT_DELAY_MS = 3000;

        // Fully managed with automatic connection handling
        public bool IsConnected { get; set; }
        private bool _isReconnecting = false;

        private ModbusDeviceConfig _modbusConfig;   // Device config as a whole Moxa E1242

        public event EventHandler? ModbusConnected;
        public event EventHandler? ModbusDisconnected;
        public event EventHandler<ModbusSnapshot>? SnapshotUpdated;

        private ModbusSnapshot? _latestSnapshot;

        public ModbusTCPService(ModbusDeviceConfig modbusConfig)
        {
            this._modbusConfig = modbusConfig;
            this._heartbeatTimer = new System.Threading.Timer(
                async _ => await HeartbeatAsync(),
                null,
                Timeout.Infinite,
                Timeout.Infinite
            );
        }

        public async Task<bool> ConnectAsync(string ipAddress, int port)
        {
            DisposeConnection();

            try
            {
                IsConnected = false;

                _ipAddress = ipAddress;
                _port = port;

                _tcpClient?.Close();
                _tcpClient?.Dispose();
                _tcpClient = new TcpClient();
                await _tcpClient.ConnectAsync(_ipAddress, _port);

                var factory = new ModbusFactory();
                _master = factory.CreateMaster(_tcpClient);

                // Handshake (maybe unavailable on some devices)
                bool handshakeOk = await ExecuteWithTimeout(HeartbeatAsync);

                if (!handshakeOk)
                {
                    return false;
                }

                _heartbeatTimer.Change(1000, POLL_CYCLE_MS);
                ModbusConnected?.Invoke(this, EventArgs.Empty);
                IsConnected = true;

                Debug.WriteLine("<Service> Modbus connected");

                return true;
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("ConnectAsync() Socket exception: " + ex.Message);
                IsConnected = false;
                return false;
            }
        }

        public async Task<bool> DisconnectAsync()
        {
            _heartbeatTimer.Change(Timeout.Infinite, Timeout.Infinite);

            try
            {
                await Task.Run(() => _tcpClient?.Close());
                await Task.Run(() => _tcpClient?.Dispose());
                await Task.Run(() => _master?.Dispose());

                IsConnected = false;
                ModbusDisconnected?.Invoke(this, EventArgs.Empty);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DisposeConnection()
        {
            try { _master?.Dispose(); } catch { }
            _master = null;

            try { _tcpClient?.Close(); } catch { }
            try { _tcpClient?.Dispose(); } catch { }
            _tcpClient = null;
        }

        private async Task HeartbeatAsync()
        {
            if (_master == null)
            {
                return;
            }

            if (!IsConnected || _isReconnecting)
            {
                return;
            }

            try
            {
                await _master.ReadHoldingRegistersAsync(_modbusConfig.SlaveId, 544, 1);   // Handshake

                // ATTENTION: READ ALL REGISTERS AT ONCE 
                await ReadAllBlocksAsync();
            }
            catch (Exception ex)
            {
                // Connection Lost
                IsConnected = false;
                ModbusDisconnected?.Invoke(this, EventArgs.Empty);

                Debug.WriteLine("<Service> Modbus disconnected");

                await AttemptReconnectAsync();

                Debug.WriteLine("Here: " + ex.Message);
            }
        }

        private async Task AttemptReconnectAsync()
        {
            if (_isReconnecting) return;
            _isReconnecting = true;

            for (int i = 0; i < RECONNECT_ATTEMPT; i++) // Try 10 times
            {
                try
                {
                    Debug.WriteLine($"Reconnecting attempt {i + 1}/{RECONNECT_ATTEMPT}...");
                    bool ok = await ConnectAsync(_ipAddress, _port);

                    if (ok)
                    {
                        Debug.WriteLine("Reconnected successfully.");
                        _isReconnecting = false;
                        return;
                    }
                }
                catch (SocketException ex)
                {
                    await Task.Delay(RECONNECT_DELAY_MS);
                    Debug.WriteLine("Reconnect Socket exception: " + ex.Message);
                }
            }

            _isReconnecting = false;
        }

        private async Task<bool> ExecuteWithTimeout(Func<Task> action, int timeoutMs = 2000)
        {
            var task = action();
            var delay = Task.Delay(timeoutMs);

            if (await Task.WhenAny(task, delay) == delay)
                return false; // timeout

            await task; // propagate exceptions
            return true;
        }

        public double ReadAnalogInput(string tag)   // Unused, but can be used for single value read if needed
        {
            try
            {
                if (_latestSnapshot != null)
                {
                    var reg = _modbusConfig.Registers[tag];
                    var inputRegisters = _latestSnapshot.InputRegisters;

                    var raw = inputRegisters[reg.Length - reg.StartAddress - 1];   // Correct for 1-register value

                    var engValue = ConvertRawToEngineering(
                        raw,
                        _modbusConfig.MinADC, _modbusConfig.MaxADC,
                        reg.MinMeasure, reg.MaxMeasure
                    );

                    return engValue;
                }

                return 0.0f;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot read {tag}: " + ex.Message);
            }
        }

        public IReadOnlyList<SensorDatum> ExtractSensorValues(ModbusSnapshot snapshot)
        {
            try
            {
                if (snapshot == null)
                    return Array.Empty<SensorDatum>();

                var list = new List<SensorDatum>();
                var now = DateTime.Now;

                foreach (var kv in _modbusConfig.Registers)
                {
                    var tag = kv.Key;
                    var reg = kv.Value;

                    int raw = 0;
                    if (!snapshot.InputRegisters.IsNullOrEmpty())
                    {
                        raw = snapshot.InputRegisters[reg.StartAddress];
                    }
                    else
                    {
                        continue;
                    }

                    double eng = ConvertRawToEngineering(
                        raw,
                        _modbusConfig.MinADC, _modbusConfig.MaxADC,
                        reg.MinMeasure, reg.MaxMeasure
                    );

                    list.Add(new SensorDatum
                    {
                        SensorId = reg.Id,   // matches Sensor.SensorId
                        RawValue = raw,
                        EngineeringValue = Convert.ToDecimal(eng),
                        QualityStatus = "Good",
                        Timestamp = now
                    });

                    // Debug.WriteLine("Added sensor with Id: " + reg.Id);
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot extract sensor values: " + ex.Message);
                throw new Exception("Cannot extract sensor values: " + ex.Message);
            }
        }

        public async Task ReadAllBlocksAsync()
        {
            try
            {
                bool[] coils = await _master!.ReadCoilsAsync(
                    _modbusConfig.SlaveId, 0, 4 // (0xxxx: Coils)
                ) ?? [];

                bool[] discreteInputs = await _master!.ReadInputsAsync(
                    _modbusConfig.SlaveId, 0, 4 // (1xxxx: Discrete Inputs)
                ) ?? [];

                ushort[] inputRegisters = await _master!.ReadInputRegistersAsync(
                    _modbusConfig.SlaveId, 512, 4 // Read first 4 AIs (3xxxx: Input Registers)
                ) ?? [];

                ushort[] holdingRegisters = await _master!.ReadHoldingRegistersAsync(
                    _modbusConfig.SlaveId, 544, 4 // (4xxxx: Holding Registers)
                ) ?? [];

                var snapshot = new ModbusSnapshot(coils, discreteInputs, inputRegisters, holdingRegisters);

                Interlocked.Exchange(ref _latestSnapshot, snapshot);

                SnapshotUpdated?.Invoke(this, snapshot);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot read MODBUS BLOCKS: " + ex.Message);
                throw new Exception("Cannot read MODBUS BLOCKS: " + ex.Message);
            }
        }

        public async Task WriteAllDigitalOutputsAsync(bool[] states)
        {
            try
            {
                await _master!.WriteMultipleCoilsAsync(_modbusConfig.SlaveId, 0, states);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot write all DOs: " + ex.Message);
                throw new Exception("Cannot write all DOs: " + ex.Message);
            }
        }

        public async Task WriteDigitalOutputAsync(ushort pin, bool state)
        {
            try
            {
                await _master!.WriteSingleCoilAsync(_modbusConfig.SlaveId, pin, state);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot write DO: " + ex.Message);
                throw new Exception("Cannot write DO: " + ex.Message);
            }
        }

        private static double ConvertRawToEngineering(
            int raw,
            int minADC, int maxADC,
            double minMeasure, double maxMeasure
        )
        {
            double ratio = (double)(raw - minADC) / (maxADC - minADC);
            return minMeasure + ratio * (maxMeasure - minMeasure);
        }
    }
}
