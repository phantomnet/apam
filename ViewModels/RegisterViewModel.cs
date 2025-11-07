
using apam.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace apam.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        string _alias = "";
        string _nombre = "";
        DateTime _dob = DateTime.Now;
        string _emergencia = "";
        string _ubicacion = "";
        string _cruzroja = "";
        string _dif = "";

        string _statusMessage = "";
        bool _hasStatus;
        Color _statusColor = Colors.Red;
        bool _acceptTerms;

        public string Alias { get => _alias; set => Set(ref _alias, value); }
        public string Nombre { get => _nombre; set => Set(ref _nombre, value); }
        public DateTime Dob { get => _dob; set => Set(ref _dob, value); }
        public string Emergencia { get => _emergencia; set => Set(ref _emergencia, value); }
        public string Ubicacion { get => _ubicacion; set => Set(ref _ubicacion, value); }
        public string CruzRoja { get => _cruzroja; set => Set(ref _cruzroja, value); }
        public string Dif { get => _dif; set => Set(ref _dif, value); }


        public bool AcceptTerms { get => _acceptTerms; set => Set(ref _acceptTerms, value); }
        public string StatusMessage { get => _statusMessage; set => Set(ref _statusMessage, value); }
        public bool HasStatus { get => _hasStatus; set => Set(ref _hasStatus, value); }
        public Color StatusColor { get => _statusColor; set => Set(ref _statusColor, value); }

        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

        public RegisterViewModel()
        {
            if (LocalStorageService.ApamSettings != null)
            {
                var settings = LocalStorageService.ApamSettings;
                Alias = settings.Alias ?? "";
                Nombre = settings.Nombre ?? "";
                Dob = DateTime.Parse(settings.Dob);
                Emergencia = settings.Emergencia ?? "";
                Ubicacion = settings.Ubicacion ?? "";
                CruzRoja = settings.CruzRoja ?? "";
                Dif = settings.Dif ?? "";
            }
        }

        async Task RegisterAsync()
        {
            if (string.IsNullOrEmpty(Alias) ||
                string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Emergencia) ||
                string.IsNullOrEmpty(Ubicacion) ||
                string.IsNullOrEmpty(CruzRoja) ||
                string.IsNullOrEmpty(Dif))
            {
                await Shell.Current.DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            if (Emergencia.Length < 10 ||
                Ubicacion.Length < 10 ||
                CruzRoja.Length < 10 ||
                Dif.Length < 10)
            {
                await Shell.Current.DisplayAlert("Error", "Los telefonos deben ser de 10 digitos", "OK");
                return;
            }

            var settings = new ApamSettingsModel();
            settings.IdUnico = await LocalStorageService.GetOrCreateDeviceIdAsync();
            settings.Alias = Alias;
            settings.Nombre = Nombre;
            settings.Dob = $"{Dob.Year}-{Dob.Month}-{Dob.Day}";
            settings.Emergencia = Emergencia;
            settings.Ubicacion = Ubicacion;
            settings.CruzRoja = CruzRoja;
            settings.Dif = Dif;

            var local = new LocalStorageService();
            await local.SaveDataToFile<ApamSettingsModel>(settings, "apam_settings10.json");

            //await LocalStorageService.SaveAsync("apam_settings2.json", settings);
            //LocalStorageService.MySettings = settings;

            // TODO: Replace with your real registration service + navigation
            await Shell.Current.DisplayAlert("Registrar", "Bienvenido a bordo! 🎉", "OK");

            await Shell.Current.GoToAsync("..");

            /*
            await Shell.Current.GoToAsync("..", new Dictionary<string, object>
            {
                { "currentAlias", this.Alias },
            });*/
        }

        // Boilerplate
        public event PropertyChangedEventHandler? PropertyChanged;
        void Set<T>(ref T storage, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(storage, value)) return;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}