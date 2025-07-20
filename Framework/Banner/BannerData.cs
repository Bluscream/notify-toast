using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using NotificationBanner.Banner.Position;

namespace NotificationBanner.Banner {
    /// <summary>
    /// Contains configuration data for the banner form.
    /// </summary>
    public class BannerData {
        /// <summary>
        /// Gets/sets the title of the banner
        /// </summary>
        public string? Title { get; internal set; }

        /// <summary>
        /// Gets/sets the text of the banner
        /// </summary>
        public string? Text { get; internal set; }

        /// <summary>
        /// Gets/sets the path for an image, this is optional.
        /// </summary>
        public Image? Image { get; internal set; }

        /// <summary>
        /// Position of the banner
        /// </summary>
        public IPosition? Position { get; internal set; }

        /// <summary>
        /// Set the priority of the notification
        /// If a notification is being shown a higher priority comes, it will replace it, if a lower, nothing will happens.
        /// </summary>
        public int Priority { get; set; } = -1;

        /// <summary>
        /// How long to keep the banner on the screen
        /// </summary>
        public TimeSpan Ttl { get; internal set; }
    }
}