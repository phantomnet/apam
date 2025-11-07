namespace apam
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Pages.DashboardPage), typeof(Pages.DashboardPage));
            Routing.RegisterRoute(nameof(Pages.RegisterPage), typeof(Pages.RegisterPage));
            Routing.RegisterRoute(nameof(Pages.YoutubeVideoPage), typeof(Pages.YoutubeVideoPage));
            Routing.RegisterRoute(nameof(Pages.TiktokVideoPage), typeof(Pages.TiktokVideoPage));
            Routing.RegisterRoute(nameof(Pages.YoutubePage), typeof(Pages.YoutubePage));
            Routing.RegisterRoute(nameof(Pages.JuegosPage), typeof(Pages.JuegosPage));
            Routing.RegisterRoute(nameof(Pages.TipsPage), typeof(Pages.TipsPage));
            Routing.RegisterRoute(nameof(Pages.EstadoAnimoPage), typeof(Pages.EstadoAnimoPage));
            Routing.RegisterRoute(nameof(Pages.EstadoAnimoSpeechPage), typeof(Pages.EstadoAnimoSpeechPage));
            Routing.RegisterRoute(nameof(Pages.AcercaDePage), typeof(Pages.AcercaDePage));
            Routing.RegisterRoute(nameof(Pages.CuentosPage), typeof(Pages.CuentosPage));
            Routing.RegisterRoute(nameof(Pages.RecordatorioPage), typeof(Pages.RecordatorioPage));
            Routing.RegisterRoute(nameof(Pages.RecordatorioActividadPage), typeof(Pages.RecordatorioActividadPage));
            Routing.RegisterRoute(nameof(Pages.RecordatorioTramitesPage), typeof(Pages.RecordatorioTramitesPage));
            Routing.RegisterRoute(nameof(Pages.AddRecordatorioPage), typeof(Pages.AddRecordatorioPage));
            Routing.RegisterRoute(nameof(Pages.AddRecordatorioActividadPage), typeof(Pages.AddRecordatorioActividadPage));
            Routing.RegisterRoute(nameof(Pages.AddRecordatorioTramiteage), typeof(Pages.AddRecordatorioTramiteage));
            Routing.RegisterRoute(nameof(Pages.HoroscopoPage), typeof(Pages.HoroscopoPage));
            Routing.RegisterRoute(nameof(Pages.LecturaHoroscopoPage), typeof(Pages.LecturaHoroscopoPage));
        }
    }
}
