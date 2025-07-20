#pragma warning disable CA1416 // Windows-only API

using System;
using System.IO;
using System.Windows.Forms;
using NotifyToast.Banner;

namespace NotifyToast.NotificationManager.Notification.Configuration {
    public class NotificationConfiguration : INotificationConfiguration {
        public NotificationConfiguration() {
            Icon = new NotifyIcon();
            // Removed unused property: DefaultSound
        }
        public NotifyIcon Icon { get; set; }
        public BannerPositionEnum BannerPosition { get; set; }
        public TimeSpan Ttl { get; set; }
    }
}