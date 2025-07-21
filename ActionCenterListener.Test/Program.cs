using System;
using ActionCenterListener;
using System.Threading;
using Microsoft.Toolkit.Uwp.Notifications;

class Program
{
    static void Main(string[] args)
    {
        // Set a custom AppUserModelID for toast notifications
        // ToastNotificationManagerCompat.SetAppId("ActionCenterListener.Test");

        Console.WriteLine("Starting ActionCenterListener test...");
        var poller = new ActionCenterPoller();
        Console.WriteLine($"Database path: {poller._dbPath}");
        var allNotifs = poller.GetAllNotifications();
        Console.WriteLine($"Stored notifications in Action Center DB: {allNotifs.Count}");
        poller.OnNotification += notif =>
        {
            if (notif.Payload != null)
            {
                Console.WriteLine($"[{notif.Timestamp}] {notif.AppId}: {notif.Payload.ToastTitle} - {notif.Payload.ToastBody}");
            }
        };

        // Try to create a test notification
        try
        {
            CreateTestNotification();
            Console.WriteLine("Test notification sent.");
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
