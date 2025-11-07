namespace apam.Pages;

public partial class RecordatorioActividadPage : ContentPage
{
    private bool isFirstAppearance = true;

    public RecordatorioActividadPage()
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

        BindingContext = new ViewModels.RecordatoriosActividadFisicaViewModel();
    }

    private async void OnAddRecordatorioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("AddRecordatorioActividadPage");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not null and string Id)
        {
            var route = $"AddRecordatorioActividadPage?idRecordatorio={Id}";
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
                var context = BindingContext as ViewModels.RecordatoriosActividadFisicaViewModel ?? new ViewModels.RecordatoriosActividadFisicaViewModel();
                await context.DeleteRecordatorioAsync(Id);
            }
        }
    }

}