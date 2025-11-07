using apam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apam.ViewModels
{
    public class HoroscopoViewModel
    {
        public List<HoroscopoItemModel> Items { get; }
        public bool IsBusy { get; set; } = false;
        public string SignoUsuario { get; set; } = "";

        public HoroscopoViewModel()
        {
            SignoUsuario = $"Eres {LocalStorageService.GetZodiacSignSimple()}";

            Items = new List<HoroscopoItemModel>
            {
                new HoroscopoItemModel { Signo = "Aries", Imagen = "aries.png" },
                new HoroscopoItemModel { Signo = "Tauro", Imagen = "tauro.png" },
                new HoroscopoItemModel { Signo = "Géminis", Imagen = "geminis.png" },
                new HoroscopoItemModel { Signo = "Cáncer", Imagen = "cancer.png" },
                new HoroscopoItemModel { Signo = "Leo", Imagen = "leo.png" },
                new HoroscopoItemModel { Signo = "Virgo", Imagen = "virgo.png" },
                new HoroscopoItemModel { Signo = "Libra", Imagen = "libra.png" },
                new HoroscopoItemModel { Signo = "Escorpio", Imagen = "escorpio.png" },
                new HoroscopoItemModel { Signo = "Sagitario", Imagen = "sagitario.png" },
                new HoroscopoItemModel { Signo = "Capricornio", Imagen = "capricornio.png" },
                new HoroscopoItemModel { Signo = "Acuario", Imagen = "acuario.png" },
                new HoroscopoItemModel { Signo = "Piscis", Imagen = "piscis.png" },
            };
        }
    }

    public class HoroscopoItemModel
    {
        public string Signo { get; set; }
        public string Imagen { get; set; }
    }
}
