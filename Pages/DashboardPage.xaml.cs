using apam.Models;
using CommunityToolkit.Maui.Views;

namespace apam.Pages;

public partial class DashboardPage : ContentPage
{
    public TrackItem selectedTrack;

    public DashboardPage()
	{
		InitializeComponent();

        selectedTrack = new TrackItem();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // back to previous (MainPage)
    }

    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;

        if (button.CommandParameter.ToString() == "pause")
        {
            button.Source = "play.png";
            button.CommandParameter = "play";
            MediaPlayer.Pause();
        }
        else if (button.CommandParameter.ToString() == "play")
        {
            button.Source = "pause.png";
            button.CommandParameter = "pause";
            MediaPlayer.Play();
        }
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MediaPlayer.Stop();

        selectedTrack = e.CurrentSelection.FirstOrDefault() as TrackItem ?? new TrackItem();
        imgCover.Source = selectedTrack.Thumb;
        lblRadioTitle.Text = selectedTrack.Title;
        lblRadioSubTitle.Text = selectedTrack.SubTitle;

        if (selectedTrack.Link == "")
            return;

        MediaPlayer.Source = MediaSource.FromUri(selectedTrack.Link);
        btnPlayPause.Source = "pause.png";
        btnPlayPause.CommandParameter = "pause";
        MediaPlayer.Play();

        btnPlayPause.IsVisible = true;
    }
}