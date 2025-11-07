using System.Text.Json;
using System.Text.Json.Serialization;

namespace apam.Services
{
    public sealed class WeatherService
    {
        private static readonly HttpClient _http = new HttpClient();

        private static readonly JsonSerializerOptions _jsonOpts = new(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<GeocodeResult?> GeocodeAsync(string query, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(query)) return null;
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(query)}&count=1&language=en&format=json";
            using var res = await _http.GetAsync(url, ct);
            res.EnsureSuccessStatusCode();
            var json = await res.Content.ReadAsStringAsync(ct);
            var data = JsonSerializer.Deserialize<GeocodingResponse>(json, _jsonOpts);
            return data?.Results?.FirstOrDefault();
        }

        public async Task<ForecastResponse?> GetForecastAsync(double latitude, double longitude, CancellationToken ct = default)
        {
            // current_weather + hourly temperature (in your local tz automatically)
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=temperature_2m&timezone=auto";
            using var res = await _http.GetAsync(url, ct);
            res.EnsureSuccessStatusCode();
            var json = await res.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<ForecastResponse>(json, _jsonOpts);
        }
    }

    public sealed class GeocodingResponse
    {
        [JsonPropertyName("results")] public List<GeocodeResult>? Results { get; set; }
    }

    public sealed class GeocodeResult
    {
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("country")] public string? Country { get; set; }
        public override string ToString() => string.IsNullOrEmpty(Country) ? Name ?? "" : $"{Name}, {Country}";
    }

    public sealed class ForecastResponse
    {
        [JsonPropertyName("latitude")] public double Latitude { get; set; }
        [JsonPropertyName("longitude")] public double Longitude { get; set; }
        [JsonPropertyName("timezone")] public string? Timezone { get; set; }
        [JsonPropertyName("current_weather")] public CurrentWeather? CurrentWeather { get; set; }
        [JsonPropertyName("hourly")] public HourlyBlock? Hourly { get; set; }
    }

    public sealed class CurrentWeather
    {
        [JsonPropertyName("temperature")] public double Temperature { get; set; }
        [JsonPropertyName("windspeed")] public double WindSpeed { get; set; }
        [JsonPropertyName("winddirection")] public double WindDirection { get; set; }
        [JsonPropertyName("weathercode")] public int WeatherCode { get; set; }
        [JsonPropertyName("is_day")] public int IsDay { get; set; }
        [JsonPropertyName("time")] public DateTime Time { get; set; }
    }

    public sealed class HourlyBlock
    {
        [JsonPropertyName("time")] public List<DateTime>? Time { get; set; }
        [JsonPropertyName("temperature_2m")] public List<double>? Temperature2m { get; set; }
    }
}
