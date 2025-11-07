using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;

namespace apam
{
    public sealed class SpeechToTextService : Java.Lang.Object, ISpeechToText, IRecognitionListener
    {
        readonly Context _context = Platform.AppContext!;
        SpeechRecognizer? _recognizer;
        Intent? _intent;

        public bool IsSupported => SpeechRecognizer.IsRecognitionAvailable(_context);

        public event EventHandler<string>? PartialResult;
        public event EventHandler<string>? FinalResult;
        public event EventHandler<string>? Error;

        public async Task<bool> StartAsync(CancellationToken ct = default)
        {
            // Permission
            var status = await Permissions.RequestAsync<Permissions.Microphone>();
            if (status != PermissionStatus.Granted)
            {
                Error?.Invoke(this, "Microphone permission denied.");
                return false;
            }

            if (!IsSupported)
            {
                Error?.Invoke(this, "Speech recognition not available on this device.");
                return false;
            }

            // Build recognizer & intent
            _recognizer?.Destroy();
            _recognizer = SpeechRecognizer.CreateSpeechRecognizer(_context);
            _recognizer.SetRecognitionListener(this);

            _intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            _intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            _intent.PutExtra(RecognizerIntent.ExtraCallingPackage, _context.PackageName);
            //_intent.PutExtra(RecognizerIntent.ExtraPartialResults, true);
            _intent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            // Use device default language. Optionally: new Java.Util.Locale("en", "US")
            _intent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);

            //_intent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 2000);  // 2s
            //_intent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 3000);          // 3s
            //_intent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 5000);

            _recognizer.StartListening(_intent);
            return true;
        }

        public void Stop()
        {
            try { _recognizer?.StopListening(); } catch { /* ignore */ }
        }

        // --- IRecognitionListener ---
        public void OnBeginningOfSpeech() { }
        public void OnBufferReceived(byte[]? buffer) { }
        public void OnEndOfSpeech() { }
        public void OnEvent(int eventType, Bundle? @params) { }
        public void OnReadyForSpeech(Bundle? @params) { }
        public void OnRmsChanged(float rmsdB) { }

        public void OnError([GeneratedEnum] SpeechRecognizerError error)
        {
            var msg = error switch
            {
                SpeechRecognizerError.Audio => "Audio error",
                SpeechRecognizerError.Client => "Client error",
                SpeechRecognizerError.Network => "Network error",
                SpeechRecognizerError.NetworkTimeout => "Network timeout",
                SpeechRecognizerError.NoMatch => "No match",
                SpeechRecognizerError.RecognizerBusy => "Recognizer busy",
                SpeechRecognizerError.SpeechTimeout => "Speech timeout",
                _ => $"Error: {error}"
            };
            Error?.Invoke(this, msg);
        }

        public void OnPartialResults(Bundle? partialResults)
        {
            var list = partialResults?.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            var text = list?.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(text))
                PartialResult?.Invoke(this, text!);
        }

        public void OnResults(Bundle? results)
        {
            var list = results?.GetStringArrayList(SpeechRecognizer.ResultsRecognition);
            var text = list?.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(text))
                FinalResult?.Invoke(this, text!);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _recognizer?.Destroy();
                _recognizer?.Dispose();
                _intent?.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}