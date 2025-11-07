using apam.Services;
using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class RecordatoriosViewModel
    {
        public ObservableCollection<Recordatorios> Medicinas { get; set; } = new ObservableCollection<Recordatorios>();
        public bool IsBusy { get; set; } = false;

        public RecordatoriosViewModel()
        {
            Medicinas = apam.Services.LocalStorageService.Medicinas ?? new ObservableCollection<Recordatorios>();
        }

        public async Task DeleteRecordatorioAsync(string id)
        {
            try
            {
                IsBusy = true;
                var recordatorioToRemove = Medicinas.FirstOrDefault(r => r.Id == id);
                if (recordatorioToRemove != null)
                {
                    var medicinas = LocalStorageService.Medicinas ?? new ObservableCollection<Recordatorios>();
                    medicinas.Remove(recordatorioToRemove);
                    var local = new LocalStorageService();
                    await local.SaveDataToFile<ObservableCollection<Recordatorios>>(medicinas, "apam_medicinas.json");
                    LocalStorageService.Medicinas = medicinas;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                System.Diagnostics.Debug.WriteLine($"Error al eliminar el recordatorio: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public class RecordatoriosActividadFisicaViewModel
    {
        public ObservableCollection<Recordatorios> ActividadFisica { get; set; } = new ObservableCollection<Recordatorios>();

        public bool IsBusy { get; set; } = false;

        public RecordatoriosActividadFisicaViewModel()
        {
            ActividadFisica = apam.Services.LocalStorageService.ActividadFisica ?? new ObservableCollection<Recordatorios>();
        }

        public async Task DeleteRecordatorioAsync(string id)
        {
            try
            {
                IsBusy = true;
                var recordatorioToRemove = ActividadFisica.FirstOrDefault(r => r.Id == id);
                if (recordatorioToRemove != null)
                {
                    var actividadFisica = LocalStorageService.ActividadFisica ?? new ObservableCollection<Recordatorios>();
                    actividadFisica.Remove(recordatorioToRemove);
                    var local = new LocalStorageService();
                    await local.SaveDataToFile<ObservableCollection<Recordatorios>>(actividadFisica, "apam_actividad.json");
                    LocalStorageService.ActividadFisica = actividadFisica;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                System.Diagnostics.Debug.WriteLine($"Error al eliminar el recordatorio: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public class RecordatoriosTramiteViewModel
    {
        public ObservableCollection<Recordatorios> Tramites { get; set; } = new ObservableCollection<Recordatorios>();

        public bool IsBusy { get; set; } = false;

        public RecordatoriosTramiteViewModel()
        {
            Tramites = apam.Services.LocalStorageService.Tramites ?? new ObservableCollection<Recordatorios>();
        }

        public async Task DeleteRecordatorioAsync(string id)
        {
            try
            {
                IsBusy = true;
                var recordatorioToRemove = Tramites.FirstOrDefault(r => r.Id == id);
                if (recordatorioToRemove != null)
                {
                    var tramites = LocalStorageService.Tramites ?? new ObservableCollection<Recordatorios>();
                    tramites.Remove(recordatorioToRemove);
                    var local = new LocalStorageService();
                    await local.SaveDataToFile<ObservableCollection<Recordatorios>>(tramites, "apam_tramites.json");
                    LocalStorageService.Tramites = tramites;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                System.Diagnostics.Debug.WriteLine($"Error al eliminar el recordatorio: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public class Recordatorios
    {
        public string Id { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Dosis { get; set; } = string.Empty;
        public DateTime Hora { get; set; } = DateTime.Now;
        public string HoraDescripcion { get; set; } = string.Empty;
    }
}
