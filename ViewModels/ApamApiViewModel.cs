using apam.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace apam.ViewModels
{
    public class ApamApiViewModel : INotifyPropertyChanged
    {
        readonly IApamApiService _api;
        CancellationTokenSource? _cts;

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string? p = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        public ApamApiViewModel(IApamApiService api) => _api = api;

        string _query = "";
        public string Query { get => _query; set { _query = value; OnPropertyChanged(); } }

        bool _isBusy;
        public bool IsBusy { get => _isBusy; private set { _isBusy = value; OnPropertyChanged(); } }


        string _id = "";
        public string Id { get => _id; set { _id = value; OnPropertyChanged(); } }

        string _userName = "";
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(); } }

        string _emergencia = "";
        public string Emergencia { get => _emergencia; set { _emergencia = value; OnPropertyChanged(); } }

        public async Task LoadAsync()
        {
            if (IsBusy) return;

            IsBusy = true;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                var register = await _api.GetRegisterAsync(Query, _cts.Token);
                if (register != null)
                {
                    Id = register.IdUnico ?? "";
                    UserName = register.Alias ?? "";
                    Emergencia = register.Emergencia ?? "";
                }
            }
            catch (TaskCanceledException) { /* ignore */ }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { IsBusy = false; }
        }


        public async Task LoadValuesAsync()
        {
            if (IsBusy) return;

            IsBusy = true;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                var register = await _api.GetValuesAsync(Query, _cts.Token);
                if (register != null)
                {
                    await Shell.Current.DisplayAlert("APAM", register, "OK");
                }
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
