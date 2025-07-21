using System;
using ActionCenterListener;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting ActionCenterListener test...");
        var poller = new ActionCenterPoller();
        poller.OnNotification += notif =>
        {
            Console.WriteLine($"[{notif.Timestamp}] {notif.AppId}: {notif.Title} - {notif.Body}");
        };

        // Try to create a test notification (if Microsoft.Toolkit.Uwp.Notifications is available)
        try
        {
            CreateTestNotification();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not create test notification: {ex.Message}");
        }

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
        poller.Dispose();
    }

    static void CreateTestNotification()
    {
        // This requires Microsoft.Toolkit.Uwp.Notifications NuGet package
        // and Windows 10+.
        var toastContent = new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
            .AddText("Test Notification")
            .AddText("This is a test notification from ActionCenterListener.Test!")
            .Show();
    }
}
