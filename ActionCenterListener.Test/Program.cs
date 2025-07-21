using System;
using ActionCenterListener;
using System.Threading;
using Microsoft.Toolkit.Uwp.Notifications;

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

        // Try to create a test notification
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
        new ToastContentBuilder()
            .AddText("Test Notification")
            .AddText("This is a test notification from ActionCenterListener.Test!")
            .Show();
    }
}
