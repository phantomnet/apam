using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;

namespace apam
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { "com.apam.ALARM_TRIGGERED" })]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            string title = intent.GetStringExtra("title") ?? "APAM";
            string message = intent.GetStringExtra("message") ?? "Tienes que tomar la medicina!";

            // Show notification when alarm triggers
            ShowNotification(context, title, message);
        }

        private void ShowNotification(Context context, string title, string message)
        {
            var channelId = "alarm_channel";
            var notificationManager = NotificationManager.FromContext(context);

            // Create channel if necessary (Android 8.0+)
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(channelId, "Alarm Notifications", NotificationImportance.High);
                notificationManager.CreateNotificationChannel(channel);
            }

            var builder = new Notification.Builder(context, channelId)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetSmallIcon(Resource.Drawable.apam_icon)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Ringtone)) // Use default alarm sound
                .SetAutoCancel(true);

            notificationManager.Notify(0, builder.Build());
        }
    }
}
