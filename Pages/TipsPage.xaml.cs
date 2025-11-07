namespace apam.Pages;

public partial class TipsPage : ContentPage
{
	public TipsPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (Services.TextToSpeechService.IsSpeaking)
            return;
        if (e.Parameter is not string tip)
            return;
        if (string.IsNullOrEmpty(tip))
            return;

        var tipIndex = int.Parse(tip.Substring(0, 2)) - 1;
        var item = ((ViewModels.TipsViewModel)BindingContext).Items[tipIndex];
        var info = $"Combinación: {item.Combinacion.Remove(item.Combinacion.Length - 3).Trim()}. Uso: {item.Uso}. Modo de uso: {item.ModoUso}. Beneficios: {item.Beneficios}. Precauciones: {item.Precauciones}.";
        _ = Services.TextToSpeechService.SpeakWithLocaleAsync(info);
    }
}