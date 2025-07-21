#pragma warning disable CA1416 // Windows-only API
using System.Runtime.InteropServices;
using NotificationBanner.Model;
using System.Linq;
using System.Collections.Generic;

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

            // Manual argument parsing
            var argDict = ParseArgs(args);
            string? message = GetArg(argDict, "message");
            string? title = GetArg(argDict, "title");
            string? image = GetArg(argDict, "image");
            string? position = GetArg(argDict, "position");
            string? time = GetArg(argDict, "time");

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.Error.WriteLine("--message is required. Use --message, -message, or /message.");
                return 1;
            }
            var parsedArgs = new NotificationArgs
            {
                Message = message,
                Title = title,
                Image = image,
                Position = position,
                Time = time
            };
            Application.Run(new MyApplicationContext(parsedArgs));
            return 0;
        }

        // Supports --key value, -key value, /key value
        private static Dictionary<string, string> ParseArgs(string[] args)
        {
            var dict = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if ((arg.StartsWith("--") || arg.StartsWith("-") || arg.StartsWith("/")) && arg.Length > 1)
                {
                    var key = arg.TrimStart('-','/');
                    if (i + 1 < args.Length && !args[i + 1].StartsWith("-") && !args[i + 1].StartsWith("/"))
                    {
                        dict[key] = args[i + 1];
                        i++;
                    }
                    else
                    {
                        dict[key] = "";
                    }
                }
            }
            return dict;
        }

        private static string? GetArg(Dictionary<string, string> dict, string key)
        {
            dict.TryGetValue(key, out var value);
            return value;
        }
    }

    public class NotificationArgs
    {
        public string? Message { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Position { get; set; }
        public string? Time { get; set; }
    }
}
