namespace apam.Services
{
    public class TextToSpeechService
    {
        public static bool IsSpeaking { get; private set; } = false;

        public static async Task SpeakAsync(string text, CancellationToken cancellationToken = default)
        {
            var settings = new SpeechOptions()
            {
                Volume = 1.0f,
                Pitch = 1.0f
            };

            IsSpeaking = true;
            await TextToSpeech.Default.SpeakAsync(text, settings, cancelToken: cancellationToken);
            IsSpeaking = false;
        }

        public static async Task SpeakWithLocaleAsync(string text)
        {
            var locales = await TextToSpeech.Default.GetLocalesAsync();
            var selectedLocale = locales.FirstOrDefault(l => l.Language == "es" && l.Country == "MX") ?? locales.FirstOrDefault(l => l.Language == "es");

            if (selectedLocale != null)
            {
                var settings = new SpeechOptions()
                {
                    Volume = 1.0f,
                    Pitch = 1.0f,
                    Locale = selectedLocale
                };

                IsSpeaking = true;
                await TextToSpeech.Default.SpeakAsync(text, settings);
                IsSpeaking = false;
            }
        }
    }
}
