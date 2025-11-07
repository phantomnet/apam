namespace apam.Pages;

public partial class RecordatorioPage : ContentPage
{
    private bool isFirstAppearance = true;

    public RecordatorioPage()
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

        BindingContext = new ViewModels.RecordatoriosViewModel();
    }

    private async void OnAddRecordatorioTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("AddRecordatorioPage");
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not null and string Id)
        {
            var route = $"AddRecordatorioPage?idRecordatorio={Id}";
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
                var context = BindingContext as ViewModels.RecordatoriosViewModel ?? new ViewModels.RecordatoriosViewModel();
                await context.DeleteRecordatorioAsync(Id);
            }
        }
    }
}