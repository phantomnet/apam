using apam.Services;

namespace apam.Pages;

public partial class HoroscopoPage : ContentPage
{
    GeminiService geminiService = new GeminiService();

    public HoroscopoPage()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not null and string signo)
        {
            Loader.IsVisible = true;
            ConsultarHoroscopo(signo);
        }
    }

    private void ConsultarHoroscopo(string signo)
    {
        Task.Run(async () =>
        {
            var prompt = $"Proporciona el horóscopo diario para el signo zodiacal {signo} en un solo párrafo y de manera positiva.";
            var response = await geminiService.GenerateContentAsync(prompt);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Loader.IsVisible = false;
                var response2 = response.Replace("*", "");
                LocalStorageService.LecturaHoroscopo = response2;

                var route = $"LecturaHoroscopoPage?signo={signo}";
                Shell.Current.GoToAsync(route);
            });
        });
    }
}