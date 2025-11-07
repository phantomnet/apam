namespace apam.Pages;

public partial class CuentosPage : ContentPage
{
	public CuentosPage()
	{
		InitializeComponent();

        webViewCuentos.Source = "https://www.buzzsprout.com/937792/episodes/6908321-cancion-de-navidad-dickens?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/6908321-cancion-de-navidad-dickens.js?container_id=buzzsprout-player-6908321&player=small";
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Stop video/audio by navigating to blank page
        webViewCuentos.Source = "about:blank";

        // Or reload to stop media
        // myWebView.Reload();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is string url)
        {
            webViewCuentos.Source = url;
        }
    }
}