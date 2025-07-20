using System;
using System.IO;
using System.Windows.Forms;
using NotifyToast.Banner;

namespace NotifyToast.NotificationManager.Notification.Configuration {
    public interface INotificationConfiguration {
        NotifyIcon Icon { get; set; }
        BannerPositionEnum BannerPosition { get; set; }
        TimeSpan Ttl { get; set; }
    }
}