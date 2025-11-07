using apam.Services;

namespace apam.Pages;

public partial class EstadoAnimoPage : ContentPage
{
    GeminiService geminiService = new GeminiService();

    public EstadoAnimoPage()
	{
		InitializeComponent();

        lblMain.Text = $"Hola {LocalStorageService.ApamSettings?.Alias}";
    }

    private void OnHappyTapped(object sender, TappedEventArgs e)
    {
        vslHappy.IsEnabled = false;
        vslMeh.IsVisible = false;
        vslSad.IsVisible = false;
        Procesar("Esta persona esta felíz ¿Puedes proporcionarle unas palabras para felcitarlo por ello? (sólo un resúmen por favor)");
    }

    private void OnMehTapped(object sender, TappedEventArgs e)
    {
        vslMeh.IsEnabled = false;
        vslHappy.IsVisible = false;
        vslSad.IsVisible = false;
        Procesar("Esta persona no está triste, pero tampoco feliz ¿Puedes proporcionarle unas palabras que mejoren su ánimo? (sólo un resúmen por favor)");
    }

    private void OnSadTapped(object sender, TappedEventArgs e)
    {
        vslSad.IsEnabled = false;
        vslHappy.IsVisible = false;
        vslMeh.IsVisible = false;
        Procesar("Esta persona está triste, ¿Puedes darle un consejo al respecto y además proponerle algo para mejorar su áanimo? (sólo un resúmen por favor)");
    }

    private async void Procesar(string prompt)
    {
        Loader.IsVisible = true;

        await Task.Run(async () =>
        {
            var response = await geminiService.GenerateContentAsync(prompt);
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                Loader.IsVisible = false;

                happyPicture.Source = "assistant.png";
                mehPicture.Source = "assistant.png";
                sadPicture.Source = "assistant.png";
                happyLabel.Text = "El asistente dice...";
                mehLabel.Text = "El asistente dice...";
                sadLabel.Text = "El asistente dice...";

                var response2 = response.Replace("*", "");
                lblResponse.Text = response2;
                bdResponse.IsVisible = true;
                await TextToSpeechService.SpeakWithLocaleAsync(response2);
            });
        });
    }
}