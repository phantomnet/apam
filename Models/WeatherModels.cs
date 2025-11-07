using System.Text.Json.Serialization;

namespace apam.Models
{
    public sealed class CurrentResponse
    {
        [JsonPropertyName("location")] public Location? Location { get; set; }
        [JsonPropertyName("current")] public Current? Current { get; set; }
    }

    public sealed class ForecastApiResponse
    {
        [JsonPropertyName("location")] public Location? Location { get; set; }
        [JsonPropertyName("forecast")] public Forecast? Forecast { get; set; }
    }

    public sealed class Location
    {
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("region")] public string? Region { get; set; }
        [JsonPropertyName("country")] public string? Country { get; set; }
        [JsonPropertyName("lat")] public double Lat { get; set; }
        [JsonPropertyName("lon")] public double Lon { get; set; }
        [JsonPropertyName("tz_id")] public string? TimezoneId { get; set; }
        [JsonPropertyName("localtime")] public string? Localtime { get; set; }
    }

    public sealed class Current
    {
        [JsonPropertyName("temp_c")] public double TempC { get; set; }
        [JsonPropertyName("temp_f")] public double TempF { get; set; }
        [JsonPropertyName("condition")] public Condition? Condition { get; set; }
        [JsonPropertyName("feelslike_c")] public double FeelsLikeC { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
        [JsonPropertyName("wind_kph")] public double WindKph { get; set; }
    }

    public sealed class Condition
    {
        [JsonPropertyName("text")] public string? Text { get; set; }
        [JsonPropertyName("icon")] public string? Icon { get; set; } // starts with //cdn.weatherapi.com
    }

    public sealed class Forecast
    {
        [JsonPropertyName("forecastday")] public List<ForecastDay> Days { get; set; } = new();
    }

    public sealed class ForecastDay
    {
        [JsonPropertyName("date")] public string? Date { get; set; }
        [JsonPropertyName("day")] public Day? Day { get; set; }
    }

    public sealed class Day
    {
        [JsonPropertyName("maxtemp_c")] public double MaxTempC { get; set; }
        [JsonPropertyName("mintemp_c")] public double MinTempC { get; set; }
        [JsonPropertyName("condition")] public Condition? Condition { get; set; }
    }
}
