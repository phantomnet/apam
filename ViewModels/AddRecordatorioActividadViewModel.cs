using apam.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace apam.ViewModels
{
    public class AddRecordatorioActividadViewModel : INotifyPropertyChanged
    {
        string _id = "";
        string _nombre = "";
        string _descripcion = "";
        string _dosis = "";
        TimeSpan _hora = DateTime.Now.TimeOfDay;
        DateTime _fecha = DateTime.Now;

        public string Id { get => _id; set => Set(ref _id, value); }
        public string Nombre { get => _nombre; set => Set(ref _nombre, value); }
        public string Descripcion { get => _descripcion; set => Set(ref _descripcion, value); }
        public string Dosis { get => _dosis; set => Set(ref _dosis, value); }
        public TimeSpan Hora { get => _hora; set => Set(ref _hora, value); }
        public DateTime Fecha { get => _fecha; set => Set(ref _fecha, value); }

        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

        async Task RegisterAsync()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Descripcion))
            {
                await Shell.Current.DisplayAlert("Error", "Nombre y descripción son requeridos", "OK");
                return;
            }

            //DateTime fechaHora = DateTime.Today.Add(Hora);
            DateTime fechaHora = Fecha.Date + Hora;
            var _horaDescripcion = fechaHora.ToString("D") + " - " + fechaHora.ToString("hh : mm tt");

            if (string.IsNullOrEmpty(this.Id))
            {
                var recordatorio = new Recordatorios
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Dosis = Dosis,
                    Hora = fechaHora,
                    HoraDescripcion = _horaDescripcion
                };

                var actividades = LocalStorageService.ActividadFisica ?? new System.Collections.ObjectModel.ObservableCollection<Recordatorios>();
                actividades.Add(recordatorio);

                var local = new LocalStorageService();
                await local.SaveDataToFile<ObservableCollection<Recordatorios>>(actividades, "apam_actividad.json");
                LocalStorageService.ActividadFisica = actividades;

                SetAlarm(fechaHora, _horaDescripcion);

                await Shell.Current.DisplayAlert("Recordatorio", "El recordatorio ha sido registrado", "OK");
            }
            else
            {
                var recordatorio = LocalStorageService.GetActividadById(this.Id);

                bool fechaChanged = recordatorio.Hora != fechaHora;

                recordatorio.Nombre = Nombre;
                recordatorio.Descripcion = Descripcion;
                recordatorio.Dosis = Dosis;
                recordatorio.Hora = fechaHora;
                recordatorio.HoraDescripcion = _horaDescripcion;
                var local = new LocalStorageService();
                await local.SaveDataToFile<ObservableCollection<Recordatorios>>(LocalStorageService.ActividadFisica!, "apam_actividad.json");
                LocalStorageService.ActividadFisica = await local.LoadDataFromFile<ObservableCollection<Recordatorios>>("apam_actividad.json");

                if (fechaChanged && (fechaHora.Hour > DateTime.Now.Hour ||
                        fechaHora.Minute > DateTime.Now.Minute))
                {
                    SetAlarm(fechaHora, _horaDescripcion);
                }

                await Shell.Current.DisplayAlert("Recordatorio", "El recordatorio ha sido actualizado", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }

        private void SetAlarm(DateTime fechaHora, string _horaDescripcion)
        {
#if ANDROID
            //var alarmTime = fechaHora.AddMinutes(-5);
            var requestCode = LocalStorageService.GenerateHashedDateTimeInt();
            AlarmHelper.SetAlarm(fechaHora, "Recordatorio Actividad Fisica", $"{Nombre}. {Descripcion}. {_horaDescripcion}", requestCode);
#endif
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Set<T>(ref T storage, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(storage, value)) return;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
