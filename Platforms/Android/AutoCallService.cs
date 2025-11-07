using Android;
using Android.Content;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;

using AndroidNet = Android.Net;
using Application = Android.App.Application;

namespace apam
{
    public class AutoCallService : IAutoCallService
    {
        public async Task<bool> PlaceCallAsync(string phoneNumber)
        {
            var activity = Platform.CurrentActivity!;
            var permission = Manifest.Permission.CallPhone;

            PermissionStatus status = await Permissions.RequestAsync<Permissions.Phone>();

            if (status == PermissionStatus.Granted)
            {
                // Permission granted, proceed with functionality
                var intent = new Intent(Intent.ActionCall);
                intent.SetData(AndroidNet.Uri.Parse("tel:" + phoneNumber));
                intent.SetFlags(ActivityFlags.NewTask);
                Application.Context.StartActivity(intent);
            }

            /*
            // Request runtime permission if needed
            if (ContextCompat.CheckSelfPermission(activity, permission) != (int)Permission.Granted)
            {
                var tcs = new TaskCompletionSource<bool>();

                ActivityCompat.RequestPermissions(activity, new[] { permission }, 1001);

                activity.OnRequestPermissionsResult(1001, new[] { permission }, activity.GrantResults =>
                {
                    tcs.TrySetResult(activity.GrantResults.Length > 0 && activity.GrantResults[0] == Permission.Granted);
                });

                // Hook the result once; you may already have a permissions flow—adapt as needed
                
                activity.RequestPermissionsResult += (sender, args) =>
                {
                    if (args.RequestCode == 1001)
                        tcs.TrySetResult(args.GrantResults.Length > 0 && args.GrantResults[0] == Permission.Granted);
                };

                var granted = await tcs.Task;
                if (!granted) return false;
            }*/

            return true;
        }
    }
}
