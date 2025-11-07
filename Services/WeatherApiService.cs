using apam.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace apam.Services
{
    public interface IWeatherApiService
    {
        Task<CurrentResponse?> GetCurrentAsync(string query, CancellationToken ct = default);
        Task<ForecastApiResponse?> GetForecastAsync(string query, int days = 3, CancellationToken ct = default);
    }

    public sealed class WeatherApiService(HttpClient http) : IWeatherApiService
    {
        string apiKey = "7b8d04380afb4c52905110544252310";

        static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<CurrentResponse?> GetCurrentAsync(string query, CancellationToken ct = default)
        {
            var url = $"v1/current.json?key={apiKey}&q={Uri.EscapeDataString(query)}&aqi=no&lang=es";
            return await http.GetFromJsonAsync<CurrentResponse>(url, JsonOpts, ct);
        }

        public async Task<ForecastApiResponse?> GetForecastAsync(string query, int days = 3, CancellationToken ct = default)
        {
            var url = $"v1/forecast.json?key={apiKey}&q={Uri.EscapeDataString(query)}&days={days}&aqi=no&alerts=no";
            return await http.GetFromJsonAsync<ForecastApiResponse>(url, JsonOpts, ct);
        }
    }
}
