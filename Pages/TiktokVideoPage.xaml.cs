using Microsoft.Maui.Controls.PlatformConfiguration;

namespace apam.Pages;

public partial class TiktokVideoPage : ContentPage
{
    public TiktokVideoPage()
    {
        InitializeComponent();
    }

    private void tiktokViewer_HandlerChanged(object sender, EventArgs e)
    {
#if ANDROID
        if (tiktokViewer.Handler?.PlatformView is Android.Webkit.WebView androidWebView)
        {
            androidWebView.Settings.UserAgentString = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
        }
#endif
    }
}