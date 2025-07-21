using NotificationBanner.Util;
using NotificationBanner.Banner;
using NotificationBanner.Banner.Position;
using NotificationBanner;

namespace NotificationBanner.Model {
    internal class MyApplicationContext : System.Windows.Forms.ApplicationContext {
        private readonly static Size MaxImageSize = new Size() { Width = 40, Height = 40 };
        private readonly BannerManager _bannerManager = new();
        private readonly BannerPositionFactory _bannerPositionFactory = new();
        internal MyApplicationContext(Config config) {
            // No more Config.Setup();
            BannerManager.Setup();

            var msgArg = string.IsNullOrWhiteSpace(config.Message) ? null : config.Message;
            var titleArg = string.IsNullOrWhiteSpace(config.Title) ? null : config.Title;
            var imageArg = string.IsNullOrWhiteSpace(config.Image) ? null : config.Image;
            var posArg = string.IsNullOrWhiteSpace(config.Position) ? "0" : config.Position;
            var timeArg = string.IsNullOrWhiteSpace(config.Time) ? "10" : config.Time;
            var maxImageSize = 40;

            var toastData = new BannerData();
            var parsedImage = imageArg?.ParseImage();
            if (parsedImage != null) toastData.Image = parsedImage.Resize(new Size() { Width = maxImageSize, Height = maxImageSize });
            if (msgArg != null) toastData.Text = msgArg;
            if (titleArg != null) toastData.Title = titleArg;
            if (posArg != null) {
                if (int.TryParse(posArg, out int posInt)) {
                    switch ((BannerPositionEnum)posInt) {
                        case BannerPositionEnum.TopCenter: toastData.Position = new BannerPosition(BannerPositionEnum.TopCenter); break;
                        case BannerPositionEnum.TopRight: toastData.Position = new BannerPosition(BannerPositionEnum.TopRight); break;
                        case BannerPositionEnum.BottomLeft: toastData.Position = new BannerPosition(BannerPositionEnum.BottomLeft); break;
                        case BannerPositionEnum.BottomCenter: toastData.Position = new BannerPosition(BannerPositionEnum.BottomCenter); break;
                        case BannerPositionEnum.BottomRight: toastData.Position = new BannerPosition(BannerPositionEnum.BottomRight); break;
                        case BannerPositionEnum.Center: toastData.Position = new BannerPosition(BannerPositionEnum.Center); break;
                        case BannerPositionEnum.TopLeft:
                        default: toastData.Position = new BannerPosition(BannerPositionEnum.TopLeft); break;
                    }
                } else if (Enum.TryParse<BannerPositionEnum>(posArg, true, out var posEnum)) {
                    toastData.Position = new BannerPosition(posEnum);
                } else {
                    toastData.Position = new BannerPosition(BannerPositionEnum.TopLeft);
                }
            }
            if (timeArg != null && int.TryParse(timeArg, out int seconds)) toastData.Ttl = TimeSpan.FromSeconds(seconds);
            else toastData.Ttl = TimeSpan.FromSeconds(10);

            // Remove OnAllScreens logic, revert to original single notification
            _bannerManager.ShowNotification(toastData);
        }
    }
}