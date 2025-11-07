using apam.Models;
using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class TipoVideoViewModel
    {
        public string Title { get; set; } = "Seleccione Tipo de Video";
        public string Subtitle { get; set; } = "";
        public string Tags { get; set; } = "";
        public string CoverImage { get; set; } = "youtube.png";

        public ObservableCollection<TrackItem> TiposVideo { get; } = new()
        {
            new TrackItem(1, "Videos cortos", "", "shorts", "play.png"),
            new TrackItem(2, "Humor", "", "humor", "play.png"),
            new TrackItem(3, "Noticias en Vivo", "", "noticias+en+vivo", "play.png"),
            new TrackItem(4, "Salud", "", "salud", "play.png"),
            new TrackItem(5, "Deportes", "", "deportes", "play.png"),
            new TrackItem(6, "Música", "", "musica", "play.png"),
            new TrackItem(7, "Películas", "", "Películas", "play.png"),
            new TrackItem(8, "Ayuda emocional", "", "ayuda+emocional", "play.png"),
            new TrackItem(9, "Podcasts", "", "podcasts", "play.png"),
            new TrackItem(10, "Autos", "", "automoviles", "play.png"),
            new TrackItem(11, "Esoterismo", "", "esoterismo", "play.png"),
        };
    }
}
