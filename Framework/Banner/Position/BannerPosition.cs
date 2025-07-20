using System.Drawing;
using System.Windows.Forms;

namespace NotificationBanner.Banner.Position {
    internal class BannerPosition : APosition, IPosition {
        public BannerPositionEnum TypeEnum { get; }
        public string Label { get; }
        public BannerPosition(BannerPositionEnum type) {
            TypeEnum = type;
            Label = type.ToString();
        }
        public Point GetScreenPosition(Screen screen, int height, int width, int offset) {
            switch (TypeEnum) {
                case BannerPositionEnum.TopLeft:
                    return new Point(PositionLeft(screen), PositionTop(screen, offset));
                case BannerPositionEnum.TopCenter:
                    return new Point(PositionCenterH(screen, width), PositionTop(screen, offset));
                case BannerPositionEnum.TopRight:
                    return new Point(PositionRight(screen, width), PositionTop(screen, offset));
                case BannerPositionEnum.BottomLeft:
                    return new Point(PositionLeft(screen), PositionBottom(screen, height, offset));
                case BannerPositionEnum.BottomCenter:
                    return new Point(PositionCenterH(screen, width), PositionBottom(screen, height, offset));
                case BannerPositionEnum.BottomRight:
                    return new Point(PositionRight(screen, width), PositionBottom(screen, height, offset));
                case BannerPositionEnum.Center:
                    return new Point(PositionCenterH(screen, width), PositionCenterV(screen, height));
                default:
                    return new Point(PositionLeft(screen), PositionTop(screen, offset));
            }
        }
    }
} 