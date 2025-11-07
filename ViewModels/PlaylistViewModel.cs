using apam.Models;
using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class PlaylistViewModel
    {
        public string Title { get; set; } = "Seleccione una Radio";
        public string Subtitle { get; set; } = "";
        public string Tags { get; set; } = "";
        public string CoverImage { get; set; } = "radio.png"; // add to Resources/Images

        public ObservableCollection<TrackItem> Tracks { get; } = new()
        {
            new TrackItem(1, "Cafe Romantico", "Cafe Romantico Radio", "https://panel.retrolandigital.com/listen/cafe_romantico_radio/listen", "https://cdn.onlineradiobox.com/img/l/1/7351.v85.png"),
            new TrackItem(2, "Amor", "Amor 95.3", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHSHFMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/8/7368.v18.png"),
            new TrackItem(3, "Oldies", "Oldies Internet Radio", "https://panel.retrolandigital.com/listen/oldies_internet_radio/listen", "https://cdn.onlineradiobox.com/img/l/4/7464.v32.png"),
            new TrackItem(4, "Mix 106.5", "Mix 106.5", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHDFMFMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/5/7665.v18.png"),
            new TrackItem(5, "La Mejor", "La mejor 97.7", "https://playerservices.streamtheworld.com/api/livestream-redirect/XERCFM.mp3?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/5/89285.v7.png"),
            new TrackItem(6, "El Fonografo", "El Fonografo 690 AM", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEN_AMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/8/7538.v17.png"),

            new TrackItem(7, "La Z", "La Z FM", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEQR_FMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/8/7358.v19.png"),
            new TrackItem(8, "Baladas del Recuerdo", "Baladas del Recuerdo", "https://stream.zeno.fm/x0jyivry0hhuv", "https://cdn.onlineradiobox.com/img/l/4/14764.v29.png"),
            new TrackItem(9, "Universal Stereo", "Universal Stereo Radio 88.1 FM", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHFO_FM.mp3?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/0/7370.v33.png"),
            new TrackItem(10, "Formula Melodica", "Formula Melodica", "https://s2.yesstreaming.net:9085/stream", "https://cdn.onlineradiobox.com/img/l/4/7344.v11.png"),
            new TrackItem(11, "Radio Felicidad", "Radio Felicidad", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEFRAMAAC_SC?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/1/7751.v13.png"),
            new TrackItem(12, "W Radio", "W Radio", "https://playerservices.streamtheworld.com/api/livestream-redirect/W_RADIOAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/9/7369.v14.png"),

            new TrackItem(13, "Los 40", "Los 40 Radio", "https://playerservices.streamtheworld.com/api/livestream-redirect/LOS40_MEXICOAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/1/9841.v40.png"),
            new TrackItem(14, "Cumbias Inmortales", "Cumbias Inmortales Radio", "https://panel.retrolandigital.com/listen/cumbias_inmortales_radio/listen", "https://cdn.onlineradiobox.com/img/l/9/7359.v43.png"),
            new TrackItem(15, "Estrellas de los 80s", "Estrellas de los 80s", "https://panel.retrolandigital.com/listen/estrellas_de_los_80s/listen", "https://cdn.onlineradiobox.com/img/l/5/54155.v34.png"),
            new TrackItem(16, "Match", "Disney Match", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHPOPFMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/0/51480.v26.png"),
            new TrackItem(17, "LG La Grande", "LG La Grande 95.5 FM", "https://stream.zeno.fm/9ty3tty0ra0uv", "https://cdn.onlineradiobox.com/img/l/4/10144.v18.png"),
            new TrackItem(18, "88.9 Noticias", "88.9 Noticias", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHMFMAAC_SC?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/4/8584.v5.png"),

            new TrackItem(19, "La Comadre", "La Comadre 1260 AM", "", "https://cdn.onlineradiobox.com/img/l/6/49906.v10.png"),
            new TrackItem(20, "La Rancherita Consentida", "La Rancherita 106.3 FM", "https://live.zuperdns.net/2063/stream/;stream.mp3", "https://cdn.onlineradiobox.com/img/l/3/15613.v9.png"),
            new TrackItem(21, "Viva el Mariachi", "Viva el Mariachi", "https://stream.zenolive.com/sy87dubz5f5tv", "https://cdn.onlineradiobox.com/img/l/5/8605.v8.png"),
            new TrackItem(22, "Radio Gallito", "Radio Gallito 760 AM", "https://playerservices.streamtheworld.com/api/livestream-redirect/GALLITO_GDL.mp3?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/7/50857.v14.png"),
            new TrackItem(23, "Radio Fórmula", "Radio Fórmula", "https://mdstrm.com/audio/6102ce7ef33d0b0830ec3adc/live.m3u8", "https://cdn.onlineradiobox.com/img/l/2/49902.v58.png"),
            new TrackItem(24, "EXA FM", "Ponte EXA FM", "https://19003.live.streamtheworld.com/XHEXA_SC", "https://cdn.onlineradiobox.com/img/l/7/7467.v20.png"),

            new TrackItem(25, "MVS Noticias", "MVS Noticias", "https://playerservices.streamtheworld.com/api/livestream-redirect/XHMVSFM_SC?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/7/7357.v12.png"),
            new TrackItem(26, "Ke Buena", "La Ke Buena", "https://playerservices.streamtheworld.com/api/livestream-redirect/KEBUENAAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/1/50821.v16.png"),
            new TrackItem(27, "Imagen Radio", "Imagen Radio", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEDAFM.mp3?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/8/51148.v17.png"),
            new TrackItem(28, "Stereo Cien", "Stereo Cien 100.1 FM", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEOYAMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/3/7663.v12.png"),
            new TrackItem(29, "Sabrosita", "Sabrosita 590 AM", "https://playerservices.streamtheworld.com/api/livestream-redirect/XEPHAMAAC.aac?dist=onlineradiobox", "https://cdn.onlineradiobox.com/img/l/6/7366.v7.png"),
            new TrackItem(30, "Radio Ranchito", "Radio Ranchito 102.5 FM", "https://streamingcwsradio30.com:7005/stream.mp3", "https://cdn.onlineradiobox.com/img/l/3/10473.v14.png"),
        };
    }
}
