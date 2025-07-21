#pragma warning disable CA1416 // Windows-only API
using System.Runtime.InteropServices;
using NotificationBanner.Model;
using System.Linq;
using System.Collections.Generic;
using System;

namespace NotificationBanner {
    internal static class Program {
        private static WindowsFormsSynchronizationContext? _synchronizationContext;
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        //[HandleProcessCorruptedStateExceptions]
        [STAThread]
        private static int Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            SetProcessDPIAware();

            Application.EnableVisualStyles();
#if NETCORE
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
            Application.SetCompatibleTextRenderingDefault(false);
            _synchronizationContext = new WindowsFormsSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(_synchronizationContext);

            var config = Config.Load(args);
            if (string.IsNullOrWhiteSpace(config.Message))
            {
                Console.Error.WriteLine("--message is required. Use --message, -message, or /message, or set it in a config file.");
                return 1;
            }
            Application.Run(new MyApplicationContext(config));
            return 0;
        }
    }
}
