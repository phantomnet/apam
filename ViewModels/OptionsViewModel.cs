using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class OptionsViewModel
    {
        public ObservableCollection<MenuItemModel> Items { get; }
        public ObservableCollection<MenuItemModel> ItemsHelpCenter { get; }
        public bool IsBusy { get; set; } = false;

        public OptionsViewModel()
        {
            Items = new ObservableCollection<MenuItemModel>
            {
                new("¿Cómo te sientes?", "calendarhoy.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "Seguimiento al estado de ánimo", "EstadoAnimoPage"),
                new("Radio en Línea", "radio.png",  Color.FromArgb("#F2C6A1"), Color.FromArgb("#23B3E6"), "Escuchar Radio", "DashboardPage"),
                new("Videos de Youtube", "youtube.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "Ver Videos", "YoutubePage"),
                new("Videos de Tiktok", "tiktok.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "Ver Videos", "TiktokVideoPage"),
                new("Juegos", "gamespad.png",  Color.FromArgb("#F2C6A1"), Color.FromArgb("#23B3E6"), "Juegos divertidos", "JuegosPage"),
                new("Audiolibros", "a1_book.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "Narración de historias", "CuentosPage"),
                new("Tips del día", "tips.png",  Color.FromArgb("#F2C6A1"), Color.FromArgb("#23B3E6"), "Combinaciones Químicas Orgánicas", "TipsPage"),
                new("Horóscopo", "horoscope.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "¿Qué le deparan las estrellas?", "HoroscopoPage"),
                new("Medicinas", "a1_pills.png",  Color.FromArgb("#BEE3C3"), Color.FromArgb("#2ECC71"), "Recordatorios", "RecordatorioPage"),
                new("Actividad Física", "a1_baseball.png",  Color.FromArgb("#BEE3C3"), Color.FromArgb("#2ECC71"), "Recordatorios", "RecordatorioActividadPage"),
                new("Pagos y Trámites", "payments2.png",  Color.FromArgb("#BEE3C3"), Color.FromArgb("#2ECC71"), "Recordatorios", "RecordatorioTramitesPage"),
                new("Llamar al 911", "a1_iphone.png",  Color.FromArgb("#93A6B8"), Color.FromArgb("#E74C3C"), "", "911"),
                new("Llamar a la Cruz Roja", "suitcase.png",  Color.FromArgb("#93A6B8"), Color.FromArgb("#E74C3C"), "", "CruzRoja"),
                new("Llamar al D.I.F.", "oldman.png",  Color.FromArgb("#93A6B8"), Color.FromArgb("#E74C3C"), "", "DIF"),
                new("Acerca de Nosotros", "team.png",  Color.FromArgb("#BDBDBD"), Color.FromArgb("#F39C12"), "¿Quiénes Somos?", "AcercaDePage"),
            };

            ItemsHelpCenter = new ObservableCollection<MenuItemModel>
            {
                new("Emergencia", "phonecall.png",  Color.FromArgb("#93A6B8"), Color.FromArgb("#E74C3C"), "","Emergencia"),
                new("Ubicación", "map.png",  Color.FromArgb("#F39C12"), Color.FromArgb("#F39C12"), "", "Ubicacion"),
            };

        }
    }

    public class MenuItemModel
    {
        public string Title { get; }
        public string? Subtitle { get; }  // optional
        public string Icon { get; }       // emoji or image path
        public Color IconBg { get; }
        public Color BandBg { get; }
        public string? Route { get; }     // optional Shell route

        public MenuItemModel(string title, string icon, Color iconBg, Color bandBg, string? subtitle = null, string? route = null)
        {
            Title = title;
            Icon = icon;
            IconBg = iconBg;
            BandBg = bandBg;
            Subtitle = subtitle;
            Route = route;
        }
    }
}
