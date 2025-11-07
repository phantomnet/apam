using Android.Content;
using AndroidNet = Android.Net;
using Application = Android.App.Application;

namespace apam
{
    public class PhoneCaller : IPhoneCaller
    {
        public void MakePhoneCall(string phoneNumber)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(AndroidNet.Uri.Parse("tel:" + phoneNumber));
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}
