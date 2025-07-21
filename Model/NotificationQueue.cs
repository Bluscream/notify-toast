using System.Collections.Concurrent;
using NotificationBanner;

namespace NotificationBanner.Model {
    internal class NotificationQueue {
        private readonly ConcurrentQueue<Config> _queue = new();
        private int _skipped = 0;
        private const int MaxQueueLength = 100;
        private readonly object _lock = new();

        public void Enqueue(Config config) {
            lock (_lock) {
                if (_queue.Count >= MaxQueueLength) {
                    _skipped++;
                    return;
                }
                _queue.Enqueue(config);
            }
        }

        public bool TryDequeue(out Config? config) {
            lock (_lock) {
                var result = _queue.TryDequeue(out config);
                if (_queue.IsEmpty && _skipped > 0) {
                    // Add a notification about skipped items
                    _queue.Enqueue(new Config {
                        Message = $"{_skipped} notifications were skipped.",
                        Title = "Notification Queue",
                        Time = "5"
                    });
                    _skipped = 0;
                }
                return result;
            }
        }

        public bool IsEmpty => _queue.IsEmpty;
    }
} 