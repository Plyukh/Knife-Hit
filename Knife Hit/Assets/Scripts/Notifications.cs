using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    [SerializeField] float hours;
    AndroidNotification notification = new AndroidNotification();
    void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotificationCenter.CancelAllNotifications();
        CreateNotification();
    }

    void CreateNotification()
    {
        notification.Title = "Hey! Come Back!";
        notification.Text = "You haven't played for 8 hours!";
        notification.FireTime = System.DateTime.Now.AddHours(hours);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
