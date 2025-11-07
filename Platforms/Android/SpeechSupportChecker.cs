using Android.Speech;

namespace apam.Platforms.Android
{
    public static class SpeechSupportChecker
    {
        public static bool IsSpeechRecognitionAvailable()
        {
            var context = Platform.AppContext;
            return SpeechRecognizer.IsRecognitionAvailable(context);
        }
    }
}
