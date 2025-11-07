using apam.Services;
using Microsoft.Maui.Controls.Shapes;

namespace apam.Pages;

public partial class EstadoAnimoSpeechPage : ContentPage
{
    GeminiService geminiService = new GeminiService();
    private bool isListening = false;
    string parcial = string.Empty;

    public EstadoAnimoSpeechPage()
	{
		InitializeComponent();

		lblMain.Text = $"Hola {LocalStorageService.ApamSettings?.Alias}";

        SetSpeechRecognition();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (LocalStorageService.SpeechToTextService != null)
        {
            LocalStorageService.SpeechToTextService.PartialResult -= OnSpeechToTextPartialResult;
            LocalStorageService.SpeechToTextService.FinalResult -= OnSpeechToTextFinalResult;
            LocalStorageService.SpeechToTextService.Error -= OnSpeechToTextError;
            LocalStorageService.SpeechToTextService.Stop();
        }
    }

    private void SetSpeechRecognition()
    {
        if (LocalStorageService.SpeechToTextService != null)
        {
            LocalStorageService.SpeechToTextService.PartialResult += OnSpeechToTextPartialResult;
            LocalStorageService.SpeechToTextService.FinalResult += OnSpeechToTextFinalResult;
            LocalStorageService.SpeechToTextService.Error += OnSpeechToTextError;
        }
    }

    private Border CreateUserBorder(string text, string backColor)
    {
        var border = new Border
        {
            Stroke = Colors.LightGray,
            StrokeThickness = 1,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10)
            },
            Padding = new Thickness(15),
            Margin = new Thickness(15),
            BackgroundColor = Color.FromArgb(backColor),
        };

        var label = new Label
        {
            Text = text,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center,
            LineBreakMode = LineBreakMode.WordWrap,
            FontSize = 18,
        };

        border.Content = label;

        return border;
    }

    private void OnSpeechToTextPartialResult(object? sender, string e)
    {
        parcial = e;
    }

    private void OnSpeechToTextFinalResult(object? sender, string e)
    {        
        isListening = false;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            if (string.IsNullOrEmpty(e))
            {
                await TextToSpeechService.SpeakWithLocaleAsync("Habla en confianza conmigo");
                imgMicro.Source = "microphone.png";
                lblMicro.Text = "Presiona el micrófono para escucharte...";
            }
            else
            {
                Loader.IsVisible = true;
                var userBorder = CreateUserBorder(e, "#4A90E2");
                viewerTalk.Children.Add(userBorder);

                var response = await geminiService.GenerateContentAsync($"Responde a este comentario, como si estuvieras hablando con esta persona: {e}");
                Loader.IsVisible = false;

                Responder.IsVisible = true;

                var _response = response.Replace("*", "").Trim();
                var responseBorder = CreateUserBorder(_response, "#7B8D93");
                viewerTalk.Children.Add(responseBorder);

                await TextToSpeechService.SpeakWithLocaleAsync(_response);

                Responder.IsVisible = false;

                imgMicro.Source = "microphone.png";
                lblMicro.Text = "Presiona el micrófono para escucharte...";
            }
        });
    }

    private void OnSpeechToTextError(object? sender, string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            //DisplayAlert("Error", message, "OK");
            //if (LocalStorageService.SpeechToTextService != null) LocalStorageService.SpeechToTextService.Stop();
            //isListening = false;
            //imgMicro.Source = "microphone.png";
            //lblMicro.Text = "Presiona el micrófono para escucharte...";
        });
    }

    private async void OnMicClicked(object sender, EventArgs e)
    {
        if (isListening)
        {
            if (LocalStorageService.SpeechToTextService != null) LocalStorageService.SpeechToTextService.Stop();
        }
        else
        {
            if (LocalStorageService.SpeechToTextService != null)
            {
                Loader.IsVisible = true;

                var started = await LocalStorageService.SpeechToTextService.StartAsync();

                Loader.IsVisible = false;

                if (!started)
                {
                    await DisplayAlert("Error", "No se pudo iniciar el reconocimiento de voz.", "OK");
                    return;
                }

                isListening = true;
                imgMicro.Source = "microphonestop.png";
                lblMicro.Text = "Presiona el micrófono cuando termines...";
            }
        }
    }
}