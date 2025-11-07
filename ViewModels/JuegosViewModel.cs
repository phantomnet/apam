using apam.Models;
using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class JuegosViewModel
    {
        public string Title { get; set; } = "Seleccione un Juego";
        public string Subtitle { get; set; } = "";
        public string Tags { get; set; } = "";
        public string CoverImage { get; set; } = "gamespad.png";

        public ObservableCollection<TrackItem> TiposJuego { get; } = new()
        {
            new TrackItem(1, "Memoria - Parejas", "", "https://wordwall.net/es/embed/6bdcf341ff65489491eab57fa33e9afb?themeId=65&templateId=25&fontStackId=0", "https://screens.cdn.wordwall.net/200/6bdcf341ff65489491eab57fa33e9afb_0"),
            new TrackItem(2, "Memoria - Vocales", "", "https://wordwall.net/es/embed/c7ce3a267e414ca692535486da06f9f5?themeId=27&templateId=25&fontStackId=0", "https://screens.cdn.wordwall.net/200/c7ce3a267e414ca692535486da06f9f5_27"),
            new TrackItem(3, "Memoria - Observar", "", "https://wordwall.net/es/embed/e62b3a9f128045878c6f667dbc5e0f55?themeId=23&templateId=23&fontStackId=0", "https://screens.cdn.wordwall.net/200/32b036d8d5714066b0e3cc9959d76ca3_0"),
            new TrackItem(4, "Memoria - Observar 2", "", "https://wordwall.net/es/embed/32b036d8d5714066b0e3cc9959d76ca3?themeId=1&templateId=23&fontStackId=0", "https://screens.cdn.wordwall.net/200/e62b3a9f128045878c6f667dbc5e0f55_23b"),
            new TrackItem(5, "Memoria - Animales", "", "https://wordwall.net/es/embed/3af6f309b25749c4bdd608fd12bb9632?themeId=2&templateId=25&fontStackId=0", "https://screens.cdn.wordwall.net/200/3af6f309b25749c4bdd608fd12bb9632_2"),
            new TrackItem(6, "Memoria - Pares", "", "https://wordwall.net/es/embed/e82de7fcdc5943b0a953c317d4ade71a?themeId=65&templateId=25&fontStackId=0", "https://screens.cdn.wordwall.net/200/e82de7fcdc5943b0a953c317d4ade71a_0"),
            new TrackItem(7, "Juego de Palabras", "", "https://wordwall.net/es/embed/19b1caa390144d23bb95d7a299fdc8f0?themeId=21&templateId=69&fontStackId=0", "https://screens.cdn.wordwall.net/200/19b1caa390144d23bb95d7a299fdc8f0_0"),
            new TrackItem(8, "Aplasta Topos", "", "https://wordwall.net/es/embed/5e7dc372380a49e6a2cf7758df563599?themeId=22&templateId=45&fontStackId=0", "https://screens.cdn.wordwall.net/200/5e7dc372380a49e6a2cf7758df563599_0"),
            new TrackItem(9, "Emociones", "", "https://wordwall.net/es/embed/4b440babf5ef4fdca31c39a6c173f345?themeId=26&templateId=5&fontStackId=0", "https://screens.cdn.wordwall.net/200/4b440babf5ef4fdca31c39a6c173f345_26b"),
            new TrackItem(10, "El Ahorcado", "", "https://wordwall.net/es/embed/ee6b41dc86ae4f8cb64fe4bf45198edf?themeId=44&templateId=73&fontStackId=0", "https://screens.cdn.wordwall.net/200/ee6b41dc86ae4f8cb64fe4bf45198edf_0"),
            new TrackItem(11, "Leer con L", "", "https://wordwall.net/es/embed/21c59e72d9af431093d986bdcbcf07a2?themeId=1&templateId=46&fontStackId=0", "https://screens.cdn.wordwall.net/200/21c59e72d9af431093d986bdcbcf07a2_0"),
            new TrackItem(12, "Leer con M y S", "", "https://wordwall.net/es/embed/36a71e9c8c9c42bf9f07d221726e4ab4?themeId=1&templateId=46&fontStackId=0", "https://screens.cdn.wordwall.net/200/36a71e9c8c9c42bf9f07d221726e4ab4_0"),
            new TrackItem(13, "Ordenar Palabras", "", "https://wordwall.net/es/embed/06fe15cb99b44c4b87626e73a60f6854?themeId=1&templateId=38&fontStackId=0", "https://screens.cdn.wordwall.net/200/06fe15cb99b44c4b87626e73a60f6854_0"),
            new TrackItem(14, "Tu Futuro", "", "https://wordwall.net/es/embed/88d1459110c445b18393ca3fea7a5c1e?themeId=6&templateId=8&fontStackId=0", "https://screens.cdn.wordwall.net/200/88d1459110c445b18393ca3fea7a5c1e_6"),
            new TrackItem(15, "Número - Cantidad", "", "https://wordwall.net/es/embed/0827055c200f4aeba0ff3d1a82e71344?themeId=1&templateId=5&fontStackId=12", "https://screens.cdn.wordwall.net/200/0827055c200f4aeba0ff3d1a82e71344_1"),
        };
    }
}
