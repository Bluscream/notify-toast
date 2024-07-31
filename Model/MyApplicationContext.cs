using notify_toast.Util;
using SoundSwitch.Framework.Banner;
using SoundSwitch.Framework.Banner.Position;

namespace notify_toast.Model {
    internal class MyApplicationContext : System.Windows.Forms.ApplicationContext {
        private readonly static Size MaxImageSize = new Size() { Width = Config.MaxImageSize, Height = Config.MaxImageSize };
        private readonly BannerManager _bannerManager = new();
        private readonly BannerPositionFactory _bannerPositionFactory = new();
        internal MyApplicationContext(string[] args) {
            Config.Setup();
            BannerManager.Setup();

            var msgArg = args.Length > 0 ? args[0] : null;
            var titleArg = args.Length > 1 ? args[1] : null;
            var imageArg = args.Length > 2 ? args[2] : Config.Image;
            var posArg = args.Length > 3 ? args[3] : "0";
            var timeArg = args.Length > 3 ? args[3] : "10";

            var toastData = new BannerData();
            if (imageArg != null) toastData.Image = imageArg.ParseImage().Resize(MaxImageSize);
            if (msgArg != null) toastData.Text = msgArg;
            if (titleArg != null) toastData.Title = titleArg;
            if (posArg != null) {
                switch ((BannerPositionEnum)int.Parse(posArg)) {
                    case BannerPositionEnum.TopCenter: toastData.Position = new PositionTopCenter(); break;
                    case BannerPositionEnum.TopRight: toastData.Position = new PositionTopRight(); break;
                    case BannerPositionEnum.BottomLeft: toastData.Position = new PositionBottomLeft(); break;
                    case BannerPositionEnum.BottomCenter: toastData.Position = new PositionBottomCenter(); break;
                    case BannerPositionEnum.BottomRight: toastData.Position = new PositionBottomRight(); break;
                    case BannerPositionEnum.Center: toastData.Position = new PositionCenter(); break;
                    case BannerPositionEnum.TopLeft:
                    default: toastData.Position = new PositionTopLeft(); break;
                }
            }
            if (timeArg != null) toastData.Ttl = TimeSpan.FromSeconds(int.Parse(timeArg));//TimeSpan.Parse(ConfigurationManager.AppSettings.Get("BannerOnScreenTime"));
            _bannerManager.ShowNotification(toastData);
        }
    }
}