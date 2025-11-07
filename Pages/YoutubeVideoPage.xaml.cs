namespace apam.Pages;

[QueryProperty(nameof(TipoVideo), "tipoVideo")]
[QueryProperty(nameof(TipoJuego), "tipoJuego")]
public partial class YoutubeVideoPage : ContentPage
{
    public string TipoVideo
    {
        set
        {
            navigateToVideo(value);
        }
    }

    public string TipoJuego
    {
        set
        {
            navigateToJuego(value);
        }
    }

    public YoutubeVideoPage()
	{
		InitializeComponent();
    }

    private void navigateToVideo(string videoTipo)
    {
        if (videoTipo.ToLower() == "shorts")
        {
            this.Title = "Youtube - Videos Cortos";
            videoViewer.Source = $"https://m.youtube.com/shorts";
        }
        else
        {
            this.Title = $"Youtube - {videoTipo.ToLower().Replace("+"," ")}";
            videoViewer.Source = $"https://m.youtube.com/results?search_query={videoTipo}";
        }
    }

    private void navigateToJuego(string juegoLink)
    {
        this.Title = "Juegos";
        videoViewer.Source = juegoLink;
    }
}