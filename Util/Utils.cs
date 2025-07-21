using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NotificationBanner.Util {
    public static class Utils {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        public static void HideConsoleWindow() {
            try {
                var handle = GetConsoleWindow();
                if (handle != IntPtr.Zero) {
                    ShowWindow(handle, SW_HIDE);
                }
                var process = Process.GetCurrentProcess();
                if (process != null && process.MainWindowHandle != IntPtr.Zero) {
                    ShowWindow(process.MainWindowHandle, SW_HIDE);
                }
            } catch (Exception ex) {
                Console.Error.WriteLine($"Error: {ex}");
            }
        }
    }
} 