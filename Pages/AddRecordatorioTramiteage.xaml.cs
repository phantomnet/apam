namespace apam.Pages;

[QueryProperty(nameof(IdRecordatorio), "idRecordatorio")]
public partial class AddRecordatorioTramiteage : ContentPage
{
    public string IdRecordatorio
    {
        set
        {
            SetRecordatorioId(value);
        }
    }

    public AddRecordatorioTramiteage()
	{
		InitializeComponent();
	}

    private void SetRecordatorioId(string id)
    {
        this.lblTipoTitulo.Text = "Editar Recordatorio";

        if (BindingContext is ViewModels.AddRecordatorioTramitesViewModel viewModel)
        {
            var recordatorio = Services.LocalStorageService.GetTramiteById(id);
            viewModel.Id = id;
            viewModel.Nombre = recordatorio.Nombre;
            viewModel.Descripcion = recordatorio.Descripcion;
            viewModel.Fecha = recordatorio.Hora.Date;
            viewModel.Hora = recordatorio.Hora.TimeOfDay;
        }
    }

}