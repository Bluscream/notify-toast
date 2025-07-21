using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotificationBanner {
    internal class Config {
        public string? Message { get; set; }
        public string? Title { get; set; }
        public string? Time { get; set; }
        public string? MaxNumberNotification { get; set; }
        public string? NotifyUsingPrimaryScreen { get; set; }
        public ushort? MaxImageSize { get; set; }
        public string? Image { get; set; }
        public string? Position { get; set; }

        public static Config Load(string[] args) {
            var exePath = Assembly.GetEntryAssembly()?.Location ?? "";
            var exeName = Path.GetFileNameWithoutExtension(exePath);
            var exeDir = Path.GetDirectoryName(exePath) ?? Environment.CurrentDirectory;
            var userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programConfigPath = Path.Combine(exeDir, exeName + ".json");
            var userConfigPath = Path.Combine(userDir, exeName + ".json");

            var config = new Config();
            if (File.Exists(programConfigPath))
                config.LoadFromFile(programConfigPath);
            if (File.Exists(userConfigPath))
                config.LoadFromFile(userConfigPath);
            config.ParseCommandLine(args);
            return config;
        }

        public void LoadFromFile(string path) {
            try {
                var json = File.ReadAllText(path);
                var loaded = JsonSerializer.Deserialize<Config>(json);
                if (loaded == null) return;
                foreach (var prop in typeof(Config).GetProperties()) {
                    var value = prop.GetValue(loaded);
                    if (value != null) prop.SetValue(this, value);
                }
            } catch { /* ignore errors, fallback to defaults */ }
        }

        public void ParseCommandLine(string[] args) {
            for (int i = 0; i < args.Length; i++) {
                var arg = args[i];
                if ((arg.StartsWith("--") || arg.StartsWith("-") || arg.StartsWith("/")) && arg.Length > 1) {
                    var key = arg.TrimStart('-','/').ToLowerInvariant();
                    string? value = null;
                    if (i + 1 < args.Length && !args[i + 1].StartsWith("-") && !args[i + 1].StartsWith("/")) {
                        value = args[i + 1];
                        i++;
                    }
                    switch (key) {
                        case "message": Message = value; break;
                        case "title": Title = value; break;
                        case "time": Time = value; break;
                        case "maxnumbernotification": MaxNumberNotification = value; break;
                        case "notifyusingprimaryscreen": NotifyUsingPrimaryScreen = value; break;
                        case "maximagesize":
                            if (ushort.TryParse(value, out var uval)) MaxImageSize = uval;
                            break;
                        case "image": Image = value; break;
                        case "position": Position = value; break;
                    }
                }
            }
        }
    }
}
