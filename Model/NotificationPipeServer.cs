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
                            var json = await reader.ReadToEndAsync(); // Will finish when client closes pipe
                            if (!string.IsNullOrWhiteSpace(json)) {
                                try {
                                    var config = JsonSerializer.Deserialize<Config>(json);
                                    Console.WriteLine($"[PipeServer] Received notification: {config?.Title} - {config?.Message}");
                                    if (config != null) onNotificationReceived(config);
                                } catch (Exception ex) {
                                    Console.WriteLine($"[PipeServer] Error deserializing notification: {ex.Message}");
                                }
                            } else {
                                Console.WriteLine("[PipeServer] Received empty notification JSON.");
                            }
                        }
                        Console.WriteLine("[PipeServer] Pipe connection closed.");
                    }
                }
            });
        }
        public static void SendNotification(Config config) {
            try {
                using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out)) {
                    client.Connect(2000); // 2s timeout
                    var json = System.Text.Json.JsonSerializer.Serialize(config);
                    using (var writer = new StreamWriter(client) { AutoFlush = true }) {
                        writer.Write(json);
                        writer.Flush();
                        Console.WriteLine($"[PipeClient] Sent notification: {config?.Title} - {config?.Message}");
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"[PipeClient] Error sending notification: {ex.Message}");
            }
        }
    }
} 