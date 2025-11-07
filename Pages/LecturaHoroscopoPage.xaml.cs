using apam.Services;
namespace apam.Pages;

[QueryProperty(nameof(Signo), "signo")]
public partial class LecturaHoroscopoPage : ContentPage
{
    public string Signo
    {
        set
        {
            SetLecturaHoroscopo(value);
        }
    }

    public LecturaHoroscopoPage()
	{
		InitializeComponent();
    }

    private void SetLecturaHoroscopo(string signo)
    {
        var _signo = signo.ToLower().Replace("á", "a").Replace("é", "e");

        lblImagen.Source = $"{_signo}.png";
        lblSigno.Text = signo;
        lblResponse.Text = LocalStorageService.LecturaHoroscopo;
        bdResponse.IsVisible = true;

        _ = TextToSpeechService.SpeakWithLocaleAsync(LocalStorageService.LecturaHoroscopo);
    }
}