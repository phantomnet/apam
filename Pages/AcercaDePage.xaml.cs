namespace apam.Pages;

public partial class AcercaDePage : ContentPage
{
	public AcercaDePage()
	{
		InitializeComponent();
        //la "eñe" es la
        //(¿?) 
        //á, é, í, ó, ú

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(lblCuenta.Text.Replace("CLABE:", "").Trim());
        await DisplayAlert("Copiado", "Número de cuenta copiado al portapapeles.", "OK");
    }
}