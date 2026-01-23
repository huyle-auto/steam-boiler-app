using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public class ScheduleClientService : IScheduleClientService
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private CancellationTokenSource? _cts;

        private string _ip;
        private int _port;

        private bool _manualDisconnect;
        private bool _isReconnecting;

        private readonly int RECONNECT_DELAY_MS = 3000;
        private readonly int BUFFER_SIZE = 4096;

        public bool IsConnected { get; set; }

        public event EventHandler<string>? JsonReceived;
        public event EventHandler? ScheduleServerConnected;
        public event EventHandler? ScheduleServerDisconnected;

        // ---------------- PUBLIC ----------------

        public async Task<bool> ConnectAsync(string ip, int port)
        {
            _manualDisconnect = false;
            _ip = ip;
            _port = port;

            return await ConnectInternalAsync();
        }

        public async Task DisconnectAsync()
        {
            _manualDisconnect = true;

            try
            {
                _cts?.Cancel();
                _stream?.Close();
                _client?.Close();
            }
            catch { }

            IsConnected = false;
            ScheduleServerDisconnected?.Invoke(this, EventArgs.Empty);

            await Task.CompletedTask;
        }

        // ---------------- INTERNAL ----------------

        private async Task<bool> ConnectInternalAsync()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_ip, _port);

                _stream = _client.GetStream();
                _cts = new CancellationTokenSource();

                IsConnected = true;
                ScheduleServerConnected?.Invoke(this, EventArgs.Empty);

                StartReceiveLoop(_cts.Token);

                Debug.WriteLine("<JsonTcpClient> Connected");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("<JsonTcpClient> Connect failed: " + ex.Message);
                IsConnected = false;
                return false;
            }
        }

        private void StartReceiveLoop(CancellationToken token)
        {
            Task.Run(async () =>
            {
                var buffer = new byte[BUFFER_SIZE];
                var sb = new StringBuilder();

                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);

                        if (bytesRead == 0)
                            throw new SocketException(); // disconnected

                        string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        sb.Append(chunk);

                        // Process line-delimited JSON
                        while (true)
                        {
                            string current = sb.ToString();
                            int newline = current.IndexOf('\n');
                            if (newline < 0)
                                break;

                            string json = current.Substring(0, newline).Trim();
                            sb.Remove(0, newline + 1);

                            if (!string.IsNullOrWhiteSpace(json))
                                JsonReceived?.Invoke(this, json);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("<JsonTcpClient> Receive loop error: " + ex.Message);
                }
                finally
                {
                    CleanupAndReconnect();
                }
            }, token);
        }

        private async void CleanupAndReconnect()
        {
            if (_manualDisconnect)
                return;

            if (_isReconnecting)
                return;

            _isReconnecting = true;

            IsConnected = false;
            ScheduleServerDisconnected?.Invoke(this, EventArgs.Empty);

            try
            {
                _stream?.Close();
                _client?.Close();
            }
            catch { }

            while (!_manualDisconnect)
            {
                Debug.WriteLine("<JsonTcpClient> Reconnecting...");
                bool ok = await ConnectInternalAsync();
                if (ok)
                {
                    _isReconnecting = false;
                    return;
                }

                await Task.Delay(RECONNECT_DELAY_MS);
            }

            _isReconnecting = false;
        }
    }
}
