using apam.Models;
namespace apam.Pages;

public partial class YoutubePage : ContentPage
{
	public YoutubePage()
	{
		InitializeComponent();
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedTrack = e.CurrentSelection.FirstOrDefault() as TrackItem ?? new TrackItem();
        if (selectedTrack.Link == "")
            return;
        var route = $"YoutubeVideoPage?tipoVideo={selectedTrack.Link}";
        await Shell.Current.GoToAsync(route);
    }

}