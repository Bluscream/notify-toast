using System.Collections.Concurrent;
using NotificationBanner;

namespace NotificationBanner.Model {
    internal class NotificationQueue {
        private readonly ConcurrentQueue<Config> _queue = new();
        public void Enqueue(Config config) => _queue.Enqueue(config);
        public bool TryDequeue(out Config? config) => _queue.TryDequeue(out config);
        public bool IsEmpty => _queue.IsEmpty;
    }
} 