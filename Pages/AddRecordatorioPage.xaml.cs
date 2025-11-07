namespace apam.Pages;

[QueryProperty(nameof(IdRecordatorio), "idRecordatorio")]
public partial class AddRecordatorioPage : ContentPage
{
    public string IdRecordatorio
    {
        set
        {
            SetRecordatorioId(value);
        }
    }

    public AddRecordatorioPage()
	{
		InitializeComponent();
	}

    private void SetRecordatorioId(string id)
    {
        this.lblTipoTitulo.Text = "Editar Recordatorio";

        if (BindingContext is ViewModels.AddRecordatorioViewModel viewModel)
        {
            var recordatorio = Services.LocalStorageService.GetMedicinaById(id);
            viewModel.Id = id;
            viewModel.Nombre = recordatorio.Nombre;
            viewModel.Descripcion = recordatorio.Descripcion;
            viewModel.Dosis = recordatorio.Dosis;
            viewModel.Fecha = recordatorio.Hora.Date;
            viewModel.Hora = recordatorio.Hora.TimeOfDay;
        }
    }
}