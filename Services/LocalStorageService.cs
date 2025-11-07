using apam.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace apam.Services
{
    public class ApamSettingsModel
    {
        public string IdUnico { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public string Emergencia { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string CruzRoja { get; set; } = string.Empty;
        public string Dif { get; set; } = string.Empty;
    }

    public class LocalStorageService
    {
        public static ApamSettingsModel? ApamSettings { get; set; } = null;
        public static ObservableCollection<Recordatorios>? Medicinas { get; set; } = null;
        public static ObservableCollection<Recordatorios>? ActividadFisica { get; set; } = null;
        public static ObservableCollection<Recordatorios>? Tramites { get; set; } = null;
        public static string LecturaHoroscopo { get; set; } = string.Empty;

        public static ISpeechToText? SpeechToTextService;

        public static int GenerateHashedDateTimeInt()
        {
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            return timestamp.GetHashCode();
        }

        public static async Task<string> GetOrCreateDeviceIdAsync()
        {
            const string key = "device_unique_id";

            // Try to get the existing ID
            var id = await SecureStorage.GetAsync(key);

            if (id == null)
            {
                id = Guid.NewGuid().ToString();
                await SecureStorage.SetAsync(key, id);
            }

            return id;
        }

        public static Recordatorios GetMedicinaById(string id)
        {
            var recordatorio = new Recordatorios();

            try
            {
                var medicinas = LocalStorageService.Medicinas ?? new ObservableCollection<Recordatorios>();
                recordatorio = medicinas.FirstOrDefault(r => r.Id == id);
                return recordatorio ?? new Recordatorios();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener el recordatorio: {ex.Message}");
            }

            return recordatorio ?? new Recordatorios();
        }

        public static Recordatorios GetActividadById(string id)
        {
            var recordatorio = new Recordatorios();

            try
            {
                var actividades = LocalStorageService.ActividadFisica ?? new ObservableCollection<Recordatorios>();
                recordatorio = actividades.FirstOrDefault(r => r.Id == id);
                return recordatorio ?? new Recordatorios();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener el recordatorio: {ex.Message}");
            }

            return recordatorio ?? new Recordatorios();
        }

        public static Recordatorios GetTramiteById(string id)
        {
            var recordatorio = new Recordatorios();

            try
            {
                var tramites = LocalStorageService.Tramites ?? new ObservableCollection<Recordatorios>();
                recordatorio = tramites.FirstOrDefault(r => r.Id == id);
                return recordatorio ?? new Recordatorios();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener el recordatorio: {ex.Message}");
            }

            return recordatorio ?? new Recordatorios();
        }



        public async Task SaveDataToFile<T>(T data, string filename)
        {
            try
            {
                string targetFile = Path.Combine(FileSystem.AppDataDirectory, filename);
                string jsonString = JsonSerializer.Serialize(data);
                await File.WriteAllTextAsync(targetFile, jsonString);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public async Task<T> LoadDataFromFile<T>(string filename)
        {
            try
            {
                string targetFile = Path.Combine(FileSystem.AppDataDirectory, filename);

                if (!File.Exists(targetFile))
                    return default(T);

                string jsonString = await File.ReadAllTextAsync(targetFile);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return default(T);
            }
        }

        public static string GetZodiacSignSimple()
        {
            var dob = DateTime.Parse(LocalStorageService.ApamSettings?.Dob ?? DateTime.Now.ToShortDateString());
            return GetZodiacSignSimple(dob);
        }

        public static string GetZodiacSignSimple(DateTime birthDate)
        {
            int day = birthDate.Day;
            int month = birthDate.Month;

            if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Acuario";
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                return "Piscis";
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Tauro";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Géminis";
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cáncer";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Escorpio";
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagitario";
            else
                return "Capricornio";
        }
    }
}
