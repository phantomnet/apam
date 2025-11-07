using apam.Models;
namespace apam.Pages;

public partial class JuegosPage : ContentPage
{
	public JuegosPage()
	{
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedTrack = e.CurrentSelection.FirstOrDefault() as TrackItem ?? new TrackItem();
        if (selectedTrack.Link == "")
            return;
        var route = $"YoutubeVideoPage?tipoJuego={selectedTrack.Link}";
        await Shell.Current.GoToAsync(route);
    }
}