using apam.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace apam.Services
{
    public interface IApamApiService
    {
        Task<RegisterResponse?> GetRegisterAsync(string query, CancellationToken ct = default);
        Task<string?> GetValuesAsync(string query, CancellationToken ct = default);
    }

    public sealed class ApamApiService (HttpClient http) : IApamApiService
    {
        static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<RegisterResponse?> GetRegisterAsync(string query, CancellationToken ct = default)
        {
            var url = $"values";
            return await http.GetFromJsonAsync<RegisterResponse>(url, JsonOpts, ct);
        }

        public async Task<string?> GetValuesAsync(string query, CancellationToken ct = default)
        {
            var url = $"values/11";
            var response = await http.GetAsync(url, ct);

            /*
            await http.PostAsJsonAsync("values", new RegisterResponse
            {
                Id = "123",
                Username = "TestUser",
                Emergencia = "TestEmergency"
            }, ct);*/

            return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync(ct) : null;
        }

    }
}
