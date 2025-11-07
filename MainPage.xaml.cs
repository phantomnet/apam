using apam.Services;
using apam.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace apam
{
    [QueryProperty(nameof(CurrentAlias), "currentAlias")]
    public partial class MainPage : ContentPage
    {
        public string CurrentAlias
        {
            set
            {
                lblAlias.Text = $"Hola, {value}";
            }
        }

        private readonly IAutoCallService _phoneCaller;
        WeatherApiViewModel weatherViewModel;

        private bool SpeechRecognitionAvailable { get; set; } = false;

        public MainPage(IAutoCallService phoneCaller, ISpeechToText speechToText)
        {
            InitializeComponent();

            _phoneCaller = phoneCaller;
            LocalStorageService.SpeechToTextService = speechToText;

            weatherViewModel = InitializeWeatherService();

            ValidateSpeechRecognition();

            SearchWeather(false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ValidateSettings();
        }

        private async void ValidateSettings()
        {
            var local = new LocalStorageService();
            var settings = await local.LoadDataFromFile<ApamSettingsModel>("apam_settings10.json");

            if (settings == null || string.IsNullOrEmpty(settings.Alias))
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LocalStorageService.ApamSettings = null;
                    Loader.IsVisible = true;
                    NavigatedToOptions("RegisterPage");
                });
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LocalStorageService.ApamSettings = settings;
                    this.CurrentAlias = settings.Alias;
                    this.MainGrid.IsEnabled = true;
                });
            }
        }

        private async void ValidateSpeechRecognition()
        {
#if ANDROID
            SpeechRecognitionAvailable = Platforms.Android.SpeechSupportChecker.IsSpeechRecognitionAvailable();
#endif
        }

        private ApamApiViewModel InitializeApamApiService()
        {
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://camaraamx.azurewebsites.net/api/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
            IApamApiService apamApiService = new ApamApiService(httpClient);
            return new ApamApiViewModel(apamApiService);
        }

        private WeatherApiViewModel InitializeWeatherService()
        {
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.weatherapi.com/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
            IWeatherApiService weatherApiService = new WeatherApiService(httpClient);
            return new WeatherApiViewModel(weatherApiService);
        }

        private async void SearchWeather(bool speak = false)
        {
            if (TextToSpeechService.IsSpeaking) return;

            weatherViewModel.Query = "23.27603, -106.44867"; // "Mazatlán";
            await weatherViewModel.LoadAsync();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                if ((weatherViewModel.Icon ?? "").Length > 0)
                {
                    imgWeather.Source = weatherViewModel.Icon;
                }
                else
                {
                    imgWeather.Source = DateTime.Now.Hour > 5 && DateTime.Now.Hour < 19 ? "weatherday2.png" : "weathernight2.png";
                }

                if (weatherViewModel.TempC > 0)
                {
                    lblTemperature.Text = $"{weatherViewModel.TempC} °C";
                }

                //if ((weatherViewModel.Summary ?? "").Length > 0)
                //{
                //    lblTemperature.Text = lblTemperature.Text.Length > 0 ? lblTemperature.Text + " - " + weatherViewModel.Summary : weatherViewModel.Summary;
                //}

                if (speak)
                {

                    var info = $"Son las {DateTime.Now.Hour} y {DateTime.Now.Minute}. La temperatura es de {lblTemperature.Text}";
                    info = info.Replace("°C", " grados centígrados");
                    //_ = textToSpeechService.SpeakWithLocaleAsync(info);
                    _ = TextToSpeechService.SpeakWithLocaleAsync(info);
                }
            });
        }

        void OnLogoTapped(object sender, TappedEventArgs e)
        {
            Loader.IsVisible = true;
            NavigatedToOptions("RegisterPage");
        }

        void OnWeatherTapped(object sender, TappedEventArgs e)
        {
            SearchWeather(true);
        }

        async void OnOptionsTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is not string route)
                return;

            if (string.IsNullOrEmpty(route))
                return;

            try
            {
                switch (route)
                {
                    case "911":
                        EmergencyCall("911");
                        break;
                    case "CruzRoja":
                        EmergencyCall(LocalStorageService.ApamSettings?.CruzRoja ?? "911");
                        break;
                    case "DIF":
                        EmergencyCall(LocalStorageService.ApamSettings?.Dif ?? "911");
                        break;
                    default:
                        Loader.IsVisible = true;
                        NavigatedToOptions(route);
                        break;
                }

            }
            catch (Exception ex)
            {
                Loader.IsVisible = false;
                await DisplayAlert(" Error", ex.Message, "OK");
            }
        }

        async void NavigatedToOptions(string route)
        {
            if (route.ToLower().Contains("record"))
            {
                if (route.ToLower() == "recordatoriopage" && LocalStorageService.Medicinas == null)
                {
                    var local = new LocalStorageService();
                    var medicinas = await local.LoadDataFromFile<System.Collections.ObjectModel.ObservableCollection<Recordatorios>>("apam_medicinas.json");
                    LocalStorageService.Medicinas = medicinas ?? new System.Collections.ObjectModel.ObservableCollection<Recordatorios>();
                }
                else if (route.ToLower().Contains("activ") && LocalStorageService.ActividadFisica == null)
                {
                    var local = new LocalStorageService();
                    var actividades = await local.LoadDataFromFile<System.Collections.ObjectModel.ObservableCollection<Recordatorios>>("apam_actividad.json");
                    LocalStorageService.ActividadFisica = actividades ?? new System.Collections.ObjectModel.ObservableCollection<Recordatorios>();
                } 
                else if (route.ToLower().Contains("trami") && LocalStorageService.Tramites == null)
                {
                    var local = new LocalStorageService();
                    var tramites = await local.LoadDataFromFile<System.Collections.ObjectModel.ObservableCollection<Recordatorios>>("apam_tramites.json");
                    LocalStorageService.Tramites = tramites ?? new System.Collections.ObjectModel.ObservableCollection<Recordatorios>();
                }
            }

            if (route.ToLower() == "estadoanimopage")
            {
                await Shell.Current.GoToAsync(SpeechRecognitionAvailable ? "EstadoAnimoSpeechPage" : route);
            }
            else
            {
                await Shell.Current.GoToAsync(route);
            }

            Loader.IsVisible = false;
        }

        async void OnOptionsHelpTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is not string option)
                return;

            switch (option)
            {
                case "Emergencia":
                    EmergencyCall(LocalStorageService.ApamSettings?.Emergencia ?? "");
                    break;
                case "Ubicacion":
                    try
                    {
                        var phoneUbicacion = $"+521{LocalStorageService.ApamSettings?.Ubicacion ?? ""}";
                        await ShareLocationService.ShareCurrentLocationViaWhatsAppAsync(phoneUbicacion);
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", ex.Message, "OK");
                    }
                    break;
                default:
                    break;
            }
        }

        private async void EmergencyCall(string phoneNumber = "") 
        {
            try
            {
                var phone = phoneNumber;
                if (string.IsNullOrEmpty(phoneNumber)) phone = "911";
                await _phoneCaller.PlaceCallAsync(phone);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo realizar la llamada: {ex.Message}", "OK");
            }
        }
    }
}