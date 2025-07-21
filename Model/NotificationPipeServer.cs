using System;
using System.IO.Pipes;
using System.Text.Json;
using System.Threading.Tasks;
using NotificationBanner;

namespace NotificationBanner.Model {
    internal class NotificationPipeServer {
        private const string PipeName = "notify-toast-pipe";
        public void StartServer(Action<Config> onNotificationReceived) {
            Task.Run(async () => {
                while (true) {
                    using (var server = new NamedPipeServerStream(PipeName, PipeDirection.In)) {
                        await server.WaitForConnectionAsync();
                        using (var reader = new StreamReader(server)) {
                            var json = await reader.ReadToEndAsync();
                            if (!string.IsNullOrWhiteSpace(json)) {
                                try {
                                    var config = JsonSerializer.Deserialize<Config>(json);
                                    if (config != null) onNotificationReceived(config);
                                } catch { /* ignore errors */ }
                            }
                        }
                    }
                }
            });
        }
        public static void SendNotification(Config config) {
            using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out)) {
                client.Connect(2000); // 2s timeout
                var json = JsonSerializer.Serialize(config);
                using (var writer = new StreamWriter(client) { AutoFlush = true }) {
                    writer.Write(json);
                }
            }
        }
    }
} 