using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ActionCenterListener
{
    public class ActionCenterNotification
    {
        public string AppId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public long NotificationId { get; set; }
    }

    public class ActionCenterPoller : IDisposable
    {
        private readonly string _dbPath;
        private readonly Timer _timer;
        private long _lastSeenId = 0;
        private bool _isPolling = false;
        public event Action<ActionCenterNotification> OnNotification;

        public ActionCenterPoller(int pollIntervalMs = 2000)
        {
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft", "Windows", "Notifications", "wpndatabase.db");
            _timer = new Timer(Poll, null, pollIntervalMs, pollIntervalMs);
        }

        private void Poll(object state)
        {
            if (_isPolling) return;
            _isPolling = true;
            try
            {
                if (!File.Exists(_dbPath)) return;
                using var conn = new SqliteConnection($"Data Source={_dbPath}");
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT NotificationId, AppId, Title, Body, Timestamp FROM Notification WHERE NotificationId > $lastSeenId ORDER BY NotificationId ASC";
                cmd.Parameters.AddWithValue("$lastSeenId", _lastSeenId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var notif = new ActionCenterNotification
                    {
                        NotificationId = reader.GetInt64(0),
                        AppId = reader.GetString(1),
                        Title = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Body = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Timestamp = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(4)).DateTime
                    };
                    _lastSeenId = notif.NotificationId;
                    OnNotification?.Invoke(notif);
                }
            }
            catch (Exception ex)
            {
                // Optionally log or handle errors
            }
            finally
            {
                _isPolling = false;
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
} 