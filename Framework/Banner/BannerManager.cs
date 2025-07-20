#pragma warning disable CA1416 // Windows-only API

using System;
using System.Collections.Generic;
using System.Configuration;

namespace NotificationBanner.Banner {
    /// <summary>
    /// Class to manage the banners. This class is the entrypoint to show a notification banner.
    /// </summary>
    public class BannerManager {
        private static System.Threading.SynchronizationContext? _syncContext;
        internal static int MaxNumberNotification => 1; //int.Parse(ConfigurationManager.AppSettings["MaxNumberNotification"]);
        private readonly Dictionary<Guid, BannerForm> _bannerForms = new();
        private BannerForm? _singleBanner;
        private const int SPACING = 10;

        /// <summary>
        /// Show a banner notification with the given data
        /// </summary>
        /// <param name="data"></param>
        public void ShowNotification(BannerData data) {
            if (MaxNumberNotification > 1) {
                MultipleBannerShow(data);
                return;
            }

            if (_syncContext == null)
                throw new InvalidOperationException("BannerManager.Setup() must be called before ShowNotification.");

            _syncContext.Send(_ => {
                if (_singleBanner == null) {
                    _singleBanner = new BannerForm();
                    _singleBanner.Disposed += (s, e) => { Application.Exit(); };// _singleBanner = null; };
                }

                _singleBanner?.SetData(data);
            }, null);
        }

        private void MultipleBannerShow(BannerData data) {
            if (_syncContext == null)
                throw new InvalidOperationException("BannerManager.Setup() must be called before MultipleBannerShow.");
            // Execute the banner in the context of the UI thread
            _syncContext.Send(_ => {
                var banner = new BannerForm();
                banner.Disposed += (s, e) => { _bannerForms.Remove(banner.Id); };
                banner.SetData(data);
                foreach (var bannerForm in _bannerForms.Values) {
                    bannerForm.UpdateLocationOpacity(banner.Height + SPACING, 0.10, 100 / MaxNumberNotification);
                }

                _bannerForms.Add(banner.Id, banner);
            }, null);
        }

        /// <summary>
        /// Because notifications dispatched asynchronously, this method must be called in the context of the UI thread
        /// <remarks>This method requires that at least one System.Windows.Form.Control has been created or Application.Run() called</remarks>
        /// </summary>
        internal static void Setup() {
            // Grab the synchronization context of the UI thread!
            _syncContext = System.Threading.SynchronizationContext.Current;
            if (!(_syncContext is System.Windows.Forms.WindowsFormsSynchronizationContext))
                throw new InvalidOperationException("BannerManager must be called in the context of the UI thread.");
        }
    }
}