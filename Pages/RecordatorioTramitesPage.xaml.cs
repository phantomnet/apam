namespace apam.Pages;

public partial class RecordatorioTramitesPage : ContentPage
{
    private bool isFirstAppearance = true;

    public RecordatorioTramitesPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (isFirstAppearance)
        {
            isFirstAppearance = false;
            return; // Skip the first appearance
        }

        BindingContext = new ViewModels.RecordatoriosTramiteViewModel();
    }

    private async void OnAddRecordatorioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("AddRecordatorioTramiteage");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not null and string Id)
        {
            var route = $"AddRecordatorioTramiteage?idRecordatorio={Id}";
            await Shell.Current.GoToAsync(route);
        }
    }

    private async void TapGestureRecognizer_DoubleTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not null and string Id)
        {
            bool answer = await DisplayAlert("Eliminar", "Estás seguro de eliminar este Recordatorio?", "Si", "No");
            if (answer)
            {
                var context = BindingContext as ViewModels.RecordatoriosTramiteViewModel ?? new ViewModels.RecordatoriosTramiteViewModel();
                await context.DeleteRecordatorioAsync(Id);
            }
        }
    }


}