namespace apam.Pages;

[QueryProperty(nameof(IdRecordatorio), "idRecordatorio")]
public partial class AddRecordatorioActividadPage : ContentPage
{
    public string IdRecordatorio
    {
        set
        {
            SetRecordatorioId(value);
        }
    }

    public AddRecordatorioActividadPage()
	{
		InitializeComponent();
	}

    private void SetRecordatorioId(string id)
    {
        this.lblTipoTitulo.Text = "Editar Recordatorio";

        if (BindingContext is ViewModels.AddRecordatorioActividadViewModel viewModel)
        {
            var recordatorio = Services.LocalStorageService.GetActividadById(id);
            viewModel.Id = id;
            viewModel.Nombre = recordatorio.Nombre;
            viewModel.Descripcion = recordatorio.Descripcion;
            viewModel.Fecha = recordatorio.Hora.Date;
            viewModel.Hora = recordatorio.Hora.TimeOfDay;
        }
    }
}