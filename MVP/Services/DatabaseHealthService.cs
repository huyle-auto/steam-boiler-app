using Microsoft.EntityFrameworkCore;
using SteamBoilerApp.Models;
using SteamBoilerApp.MVP.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBoilerApp.MVP.Services
{
    public class DatabaseHealthService : IDatabaseHealthService, IDisposable
    {
        private readonly System.Threading.Timer _timer; // Periodically check database connection
        private readonly int POLL_CYCLE_MS = 2000;
        private bool _isConnected = false;
        public bool IsConnected => _isConnected;

        public event EventHandler? DatabaseConnected;
        public event EventHandler? DatabaseDisconnected;

        public DatabaseHealthService()
        {
            this._timer = new System.Threading.Timer(
                async _ => await CheckDBConnectionAsync(),
                null,
                Timeout.Infinite,   // Wait to fire timer
                Timeout.Infinite
            );
            this._timer.Change(1000, POLL_CYCLE_MS);
        }

        private async Task CheckDBConnectionAsync()
        {
            try
            {
                using var db = new ProductionDbContext();
                await db.Database.ExecuteSqlRawAsync("SELECT 1");

                if (!_isConnected)
                {
                    _isConnected = true;
                    DatabaseConnected?.Invoke(this, EventArgs.Empty);
                    Debug.WriteLine("DB Connected.");
                }
            }
            catch (Exception ex)
            {
                if (_isConnected)
                {
                    _isConnected = false;
                    DatabaseDisconnected?.Invoke(this, EventArgs.Empty);
                    Debug.WriteLine("DB disconnected. Health check failed: " + ex.Message);
                }
            }

        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
