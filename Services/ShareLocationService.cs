using System.Globalization;
using System.Text;

namespace apam.Services
{
    public static class ShareLocationService
    {
        /// <summary>
        /// Opens WhatsApp with a prefilled message containing a Google Maps link to the current location.
        /// If <paramref name="phoneE164"/> is provided (e.g. "+15551234567"), the chat opens to that number.
        /// </summary>
        public static async Task ShareCurrentLocationViaWhatsAppAsync(
            string? phoneE164 = null,
            string messagePrefix = "Este es un mensaje de emergencia, necesito tu ayuda. Te envio mi ubicación:")
        {
            // 1) Ensure we have permission to access location
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                    throw new InvalidOperationException("Permiso Denegado a ubicación.");
            }

            // 2) Get current location (best effort, with a sensible timeout)
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(15));
            var location = await Geolocation.Default.GetLocationAsync(request);

            if (location == null)
                throw new InvalidOperationException("No se puede determinar la ubicación.");

            var lat = location.Latitude.ToString(CultureInfo.InvariantCulture);
            var lng = location.Longitude.ToString(CultureInfo.InvariantCulture);

            // 3) Build a Google Maps link (opens in any browser / maps app)
            var mapsUrl = $"https://maps.google.com/?q={lat},{lng}";

            // 4) Compose WhatsApp message
            var message = $"{messagePrefix} {mapsUrl}";

            //await SendWhatsAppMessageAsync(phoneE164 ?? "", message);

            // 5) Prefer the native scheme if the app is installed; else fall back to wa.me (browser)
            //    a) With a specific phone:
            //       - Using wa.me is the most reliable cross-platform way to prefill + target a number
            //    b) Without a phone: try whatsapp:// first for best native UX, fall back to wa.me
            Uri? uriToOpen = null;

            if (!string.IsNullOrWhiteSpace(phoneE164))
            {
                // Target a specific recipient (E.164 format required by WhatsApp)
                var encodedText = Uri.EscapeDataString(message);
                uriToOpen = new Uri($"https://wa.me/{phoneE164.Trim()}?text={encodedText}");
                await Launcher.OpenAsync(uriToOpen);
                return;
            }
            else
            {
                // No phone specified: try native scheme then fallback
                var encodedText = Uri.EscapeDataString(message);
                var nativeUri = new Uri($"whatsapp://send?text={encodedText}");
                if (await Launcher.CanOpenAsync(nativeUri))
                {
                    await Launcher.OpenAsync(nativeUri);
                    return;
                }

                // Fallback (browser)
                uriToOpen = new Uri($"https://wa.me/?text={encodedText}");
                await Launcher.OpenAsync(uriToOpen);
                return;
            }
        }


        public static async Task<bool> SendWhatsAppMessageAsync(string to, string message)
        {
            var _accountSid = "AC9544dc9ceac67231f2eef58b100ecda2";
            var _authToken = "9d850ba55c7f57a739094634ae602d18";
            var _fromNumber = "+14155238886";

            var client = new HttpClient();
            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_accountSid}:{_authToken}"));

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);

            var formData = new List<KeyValuePair<string, string>>
            {
                new("From", $"whatsapp:{_fromNumber}"),
                new("To", $"whatsapp:{to}"),
                new("Body", message)
            };

            var response = await client.PostAsync(
                $"https://api.twilio.com/2010-04-01/Accounts/{_accountSid}/Messages.json",
                new FormUrlEncodedContent(formData)
            );

            return response.IsSuccessStatusCode;
        }
    }
}
