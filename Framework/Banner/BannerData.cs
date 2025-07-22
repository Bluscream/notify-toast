using System;
using System.Drawing;

namespace NotificationBanner.Banner {
    public class BannerData {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public Image? Image { get; set; }
        public PositionDelegate? Position { get; set; }
        public int Priority { get; set; } = -1;
        public TimeSpan Ttl { get; set; }
        public NotificationBanner.Config? Config { get; set; }

        // Delegate to calculate position
        public delegate (int x, int y) PositionDelegate(int formWidth, int formHeight, int offset);
    }
}