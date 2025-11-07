using System.Text.Json.Serialization;

namespace apam.Models
{
    public sealed class RegisterResponse
    {
        [JsonPropertyName("idUnico")] public string IdUnico { get; set; } = string.Empty;
        [JsonPropertyName("Alias")] public string Alias { get; set; } = string.Empty;
        [JsonPropertyName("nombre")] public string Nombre { get; set; } = string.Empty;
        [JsonPropertyName("emergencia")] public string Emergencia { get; set; } = string.Empty;
        [JsonPropertyName("cruzRoja")] public string CruzRoja { get; set; } = string.Empty;
        [JsonPropertyName("ubicacion")] public string Ubicacion { get; set; } = string.Empty;
        [JsonPropertyName("dif")] public string Dif { get; set; } = string.Empty;
    }
}
