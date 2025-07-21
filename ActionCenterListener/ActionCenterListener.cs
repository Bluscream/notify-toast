using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;

namespace ActionCenterListener
{
    public class ActionCenterNotification
    {
        public long Order { get; set; }
        public long NotificationId { get; set; } // maps to Id
        public long HandlerId { get; set; }
        public string? ActivityId { get; set; }
        public string? Type { get; set; }
        public string? PayloadRaw { get; set; } // Raw XML from DB
        public NotificationPayload? Payload { get; set; } // Parsed payload
        public string? Tag { get; set; }
        public string? Group { get; set; }
        public long? ExpiryTime { get; set; }
        public DateTime Timestamp { get; set; } // ArrivalTime
        public long DataVersion { get; set; }
        public string? PayloadType { get; set; }
        public long BootId { get; set; }
        public bool ExpiresOnReboot { get; set; }
        public string? AppId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }

    public class ActionCenterPoller : IDisposable
    {
        public readonly string _dbPath;
        private readonly string _dbConn;
        private readonly Timer _timer;
        private long _lastSeenId = 0;
        private bool _isPolling = false;
        public event Action<ActionCenterNotification>? OnNotification;

        private static readonly string NotificationSelectSql =
            "SELECT [Order], Id, HandlerId, ActivityId, Type, Payload, Tag, [Group], ExpiryTime, ArrivalTime, DataVersion, PayloadType, BootId, ExpiresOnReboot FROM Notification";

        public ActionCenterPoller(int pollIntervalMs = 2000)
        {
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows", "Notifications", "wpndatabase.db");
            _dbConn = $"Data Source={_dbPath};Mode=ReadOnly;Cache=Shared";
            _timer = new Timer(Poll, null, pollIntervalMs, pollIntervalMs);
        }

        public List<ActionCenterNotification> GetAllNotifications()
        {
            if (!File.Exists(_dbPath)) return new List<ActionCenterNotification>();
            try
            {
                using var conn = new SqliteConnection(_dbConn);
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = NotificationSelectSql + " ORDER BY Id ASC";
                using var reader = cmd.ExecuteReader();
                return ReadNotificationsFromReader(reader);
            }
            catch { return new List<ActionCenterNotification>(); }
        }

        private void Poll(object? state)
        {
            if (_isPolling) return;
            _isPolling = true;
            try
            {
                if (!File.Exists(_dbPath)) return;

                // On first poll, set _lastSeenId to the latest notification in the DB to avoid polling past notifications
                if (_lastSeenId == 0)
                {
                    using (var conn = new SqliteConnection(_dbConn))
                    {
                        conn.Open();
                        using var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT MAX(Id) FROM Notification";
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            _lastSeenId = Convert.ToInt64(result);
                        }
                    }
                    return; // Do not process any notifications on the first poll
                }

                using (var conn = new SqliteConnection(_dbConn))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = NotificationSelectSql + " WHERE Id > $lastSeenId ORDER BY Id ASC";
                    cmd.Parameters.AddWithValue("$lastSeenId", _lastSeenId);
                    using var reader = cmd.ExecuteReader();
                    foreach (var notif in ReadNotificationsFromReader(reader))
                    {
                        _lastSeenId = notif.NotificationId;
                        OnNotification?.Invoke(notif);
                    }
                }
            }
            catch
            {
                // Optionally log or handle errors
            }
            finally
            {
                _isPolling = false;
            }
        }

        private static List<ActionCenterNotification> ReadNotificationsFromReader(SqliteDataReader reader)
        {
            var notifications = new List<ActionCenterNotification>();
            while (reader.Read())
            {
                var payloadRaw = reader.IsDBNull(5) ? null : reader.GetString(5);
                var notif = new ActionCenterNotification
                {
                    Order = reader.GetInt64(0),
                    NotificationId = reader.GetInt64(1),
                    HandlerId = reader.GetInt64(2),
                    ActivityId = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Type = reader.IsDBNull(4) ? null : reader.GetString(4),
                    PayloadRaw = payloadRaw,
                    Payload = NotificationPayload.Parse(payloadRaw),
                    Tag = reader.IsDBNull(6) ? null : reader.GetString(6),
                    Group = reader.IsDBNull(7) ? null : reader.GetString(7),
                    ExpiryTime = reader.IsDBNull(8) ? null : reader.GetInt64(8),
                    Timestamp = DateTimeOffset.FromFileTime(reader.GetInt64(9)).DateTime,
                    DataVersion = reader.IsDBNull(10) ? 0 : reader.GetInt64(10),
                    PayloadType = reader.IsDBNull(11) ? null : reader.GetString(11),
                    BootId = reader.IsDBNull(12) ? 0 : reader.GetInt64(12),
                    ExpiresOnReboot = !reader.IsDBNull(13) && reader.GetBoolean(13)
                };
                notifications.Add(notif);
            }
            return notifications;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
} 