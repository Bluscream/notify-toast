using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using notify_toast.Model;

namespace notify_toast {
    internal static class Program {
        private static WindowsFormsSynchronizationContext _synchronizationContext;
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [HandleProcessCorruptedStateExceptions]
        [STAThread]
        private static void Main(string[] args) {
            Thread.CurrentThread.Name = "Main Thread";
            SetProcessDPIAware();

            Application.EnableVisualStyles();
#if NETCORE
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
            Application.SetCompatibleTextRenderingDefault(false);
            _synchronizationContext = new WindowsFormsSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(_synchronizationContext);
            Application.Run(new MyApplicationContext(args));
        }
    }
}
