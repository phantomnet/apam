namespace apam.ViewModels
{
    public class CuentosViewModel
    {
        public List<CuentosModel> Items { get; }
        public bool IsBusy { get; set; } = false;
        public CuentosViewModel()
        {
            Items = new List<CuentosModel>
            {
                new CuentosModel
                {
                    Titulo = "Canción de Navidad",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/6908321-cancion-de-navidad-dickens?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/6908321-cancion-de-navidad-dickens.js?container_id=buzzsprout-player-6908321&player=small"
                },
                new CuentosModel
                {
                    Titulo = "El Cascanueces",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9752412-el-cascanueces-y-el-rey-de-los-ratones-hoffmann?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9752412-el-cascanueces-y-el-rey-de-los-ratones-hoffmann.js?container_id=buzzsprout-player-9752412&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Cleopatra",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/8194296-cleopatra-la-ultima-reina-de-egipto?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/8194296-cleopatra-la-ultima-reina-de-egipto.js?container_id=buzzsprout-player-8194296&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Beethoven, el músico sordo",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9628528-beethoven-el-musico-sordo?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9628528-beethoven-el-musico-sordo.js?container_id=buzzsprout-player-9628528&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Marie Curie",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/8658924-marie-curie-la-extraordinaria-cientifica?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/8658924-marie-curie-la-extraordinaria-cientifica.js?container_id=buzzsprout-player-8658924&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Umvyn, el gnomo gruñón",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9550227-umvyn-el-gnomo-grunon?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9550227-umvyn-el-gnomo-grunon.js?container_id=buzzsprout-player-9550227&player=small"
                },
                new CuentosModel
                {
                    Titulo = "La domadora de hormigas",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9185911-la-domadora-de-hormigas?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9185911-la-domadora-de-hormigas.js?container_id=buzzsprout-player-9185911&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Las aventuras de las emociones",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/8618027-la-aventura-de-las-emociones?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/8618027-la-aventura-de-las-emociones.js?container_id=buzzsprout-player-8618027&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Historias de Halloween",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9426879-historias-de-halloween-alrededor-de-la-hoguera?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9426879-historias-de-halloween-alrededor-de-la-hoguera.js?container_id=buzzsprout-player-9426879&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Don lobo busca trabajo",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/8405467-don-lobo-busca-trabajo?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/8405467-don-lobo-busca-trabajo.js?container_id=buzzsprout-player-8405467&player=small"
                },
                new CuentosModel
                {
                    Titulo = "Caperucita rebelde",
                    Autor = "",
                    Contenido = "",
                    UrlImagen = "read.png",
                    Url = "https://www.buzzsprout.com/937792/episodes/9307771-caperucita-rebelde-en-el-pais-de-las-maravillas?client_source=small_player&iframe=true&referrer=https://www.buzzsprout.com/937792/9307771-caperucita-rebelde-en-el-pais-de-las-maravillas.js?container_id=buzzsprout-player-9307771&player=small"
                },
            };
        }
    }

    public class CuentosModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public string UrlImagen { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
