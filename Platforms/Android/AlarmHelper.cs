using Android.App;
using Android.Content;
using Java.Util;

namespace apam
{
    public static class AlarmHelper
    {
        public static void SetAlarm(DateTime alarmTime, string title, string message, int requestCode)
        {
            var context = Android.App.Application.Context;

            var intent = new Intent(context, typeof(AlarmReceiver));
            intent.PutExtra("title", title);
            intent.PutExtra("message", message);

            var pendingIntent = PendingIntent.GetBroadcast(
                context,
                requestCode,
                intent,
                PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

            var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            var calendar = Calendar.Instance;
            calendar.Set(CalendarField.Year, alarmTime.Year);
            calendar.Set(CalendarField.Month, alarmTime.Month - 1);
            calendar.Set(CalendarField.DayOfMonth, alarmTime.Day);
            calendar.Set(CalendarField.HourOfDay, alarmTime.Hour);
            calendar.Set(CalendarField.Minute, alarmTime.Minute);
            calendar.Set(CalendarField.Second, 0);

            alarmManager.SetExactAndAllowWhileIdle(
                AlarmType.RtcWakeup,
                calendar.TimeInMillis,
                pendingIntent);
        }
    }
}
