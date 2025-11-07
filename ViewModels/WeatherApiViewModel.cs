using apam.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace apam.ViewModels
{
    public sealed class WeatherApiViewModel : INotifyPropertyChanged
    {
        readonly IWeatherApiService _api;
        CancellationTokenSource? _cts;

        public WeatherApiViewModel(IWeatherApiService api) => _api = api;

        string _query = "Seattle";
        public string Query { get => _query; set { _query = value; OnPropertyChanged(); } }

        string? _location;
        public string? Location { get => _location; private set { _location = value; OnPropertyChanged(); } }

        string? _summary;
        public string? Summary { get => _summary; private set { _summary = value; OnPropertyChanged(); } }

        double _tempC;
        public double TempC { get => _tempC; private set { _tempC = value; OnPropertyChanged(); } }

        string? _icon;
        public string? Icon { get => _icon; private set { _icon = value; OnPropertyChanged(); } }

        public ObservableCollection<(string Day, double MinC, double MaxC, string? Icon)> Forecast { get; } = new();

        bool _isBusy;
        public bool IsBusy { get => _isBusy; private set { _isBusy = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? p = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        public async Task LoadAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                var current = await _api.GetCurrentAsync(Query, _cts.Token);
                if (current?.Location is not null && current.Current is not null)
                {
                    Location = $"{current.Location.Name}, {current.Location.Region}, {current.Location.Country}";
                    TempC = Math.Round(current.Current.TempC, 1);
                    Summary = current.Current.Condition?.Text ?? "—";
                    Icon = current.Current.Condition?.Icon != null ? $"https:{current.Current.Condition.Icon.Replace("64x64","128x128") }" : "";
                }

                /*
                Forecast.Clear();
                var forecast = await _api.GetForecastAsync(Query, 3, _cts.Token);
                if (forecast?.Forecast?.Days is { Count: > 0 } days)
                {
                    foreach (var d in days)
                    {
                        var date = DateTime.TryParse(d.Date, out var dt) ? dt.ToString("ddd") : d.Date ?? "";
                        Forecast.Add((date, Math.Round(d.Day?.MinTempC ?? 0, 1), Math.Round(d.Day?.MaxTempC ?? 0, 1), d.Day?.Condition?.Icon));
                    }
                }
                */
            }
            catch (TaskCanceledException) { /* ignore */ }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }
    }
}
