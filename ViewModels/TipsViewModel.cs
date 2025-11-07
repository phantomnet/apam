using System.Collections.ObjectModel;

namespace apam.ViewModels
{
    public class TipsViewModel
    {
        public ObservableCollection<TipitemModel> Items { get; }

        public bool IsBusy { get; set; } = false;

        public TipsViewModel()
        {
            Items = new ObservableCollection<TipitemModel>
            {
                new TipitemModel
                {
                    Combinacion = "01. Bicarbonato de sodio + vinagre   👈",
                    Uso = "Limpieza de superficies",
                    ModoUso = "Mezclar partes iguales, aplicar, dejar actuar 5 min y enjuagar.",
                    Beneficios = "Desinfecta, elimina grasa y malos olores.",
                    Precauciones = "No mezclar en exceso en recipientes cerrados; puede generar gas CO₂."
                },
                new TipitemModel
                {
                    Combinacion = "02. Vinagre + limón   👈",
                    Uso = "Desinfección natural",
                    ModoUso = "Combinar en spray, aplicar sobre superficies, dejar actuar 10 min.",
                    Beneficios = "Desinfecta y elimina bacterias.",
                    Precauciones = "Evitar uso sobre mármol o granito, puede dañar el brillo.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "03. Bicarbonato + agua oxigenada   👈",
                    Uso = "Blanqueador y quitamanchas",
                    ModoUso = "Formar pasta, aplicar 5–10 min y enjuagar.",
                    Beneficios = "Aclara superficies y elimina hongos.",
                    Precauciones = "Usar guantes; evitar contacto prolongado con la piel."
                },
                new TipitemModel
                {
                    Combinacion = "04. Alcohol + agua   👈",
                    Uso = "Desinfección de objetos",
                    ModoUso = "Diluir 70% alcohol, aplicar con atomizador.",
                    Beneficios = "Desinfecta rápidamente superficies.",
                    Precauciones = "Evitar cerca del fuego o fuentes de calor.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "05. Agua + jabón neutro   👈",
                    Uso = "Limpieza general",
                    ModoUso = "Disolver jabón en agua tibia, usar con paño suave.",
                    Beneficios = "Remueve suciedad sin dañar materiales.",
                    Precauciones = "No usar exceso de jabón para evitar residuos."
                },
                new TipitemModel
                {
                    Combinacion = "06. Vinagre + bicarbonato + agua caliente   👈",
                    Uso = "Desatascar cañerías",
                    ModoUso = "Verter bicarbonato, luego vinagre y agua caliente.",
                    Beneficios = "Elimina grasa y residuos orgánicos.",
                    Precauciones = "No usar con productos químicos comerciales.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "07. Aceite de oliva + limón   👈",
                    Uso = "Pulidor de madera",
                    ModoUso = "Mezclar 2 partes de aceite con 1 de limón, aplicar con trapo.",
                    Beneficios = "Da brillo y nutre la madera.",
                    Precauciones = "Evitar en superficies sin barnizar o porosas."
                },
                new TipitemModel
                {
                    Combinacion = "08. Vinagre + agua   👈",
                    Uso = "Limpieza de vidrios",
                    ModoUso = "Mezclar partes iguales, aplicar con paño o atomizador.",
                    Beneficios = "Deja vidrios brillantes sin residuos.",
                    Precauciones = "No usar sobre pantallas electrónicas.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "09. Bicarbonato + aceites esenciales   👈",
                    Uso = "Ambientador natural",
                    ModoUso = "Colocar mezcla en frasco abierto, cambiar cada 2 semanas.",
                    Beneficios = "Absorbe olores y refresca ambientes.",
                    Precauciones = "Evitar el contacto directo con mascotas o niños."
                },
                new TipitemModel
                {
                    Combinacion = "10. Sal + vinagre   👈",
                    Uso = "Eliminar óxido",
                    ModoUso = "Hacer pasta, aplicar 15 min y frotar con cepillo.",
                    Beneficios = "Remueve óxido y manchas metálicas.",
                    Precauciones = "Evitar en objetos de aluminio o con recubrimiento.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "11. Alcohol + aceites esenciales   👈",
                    Uso = "Desinfectante aromático",
                    ModoUso = "Mezclar en atomizador, agitar y aplicar sobre superficies.",
                    Beneficios = "Desinfecta y deja aroma agradable.",
                    Precauciones = "Evitar inhalación directa o aplicar sobre piel sensible."
                },
                new TipitemModel
                {
                    Combinacion = "12. Agua oxigenada + agua   👈",
                    Uso = "Desinfección de utensilios",
                    ModoUso = "Diluir 1 parte de agua oxigenada en 2 de agua, aplicar 10 min.",
                    Beneficios = "Elimina bacterias en utensilios de cocina.",
                    Precauciones = "No usar sobre metales pintados o madera.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "13. Vinagre + bicarbonato + limón   👈",
                    Uso = "Limpieza profunda de baño",
                    ModoUso = "Aplicar sobre superficies, dejar actuar 10 min y enjuagar.",
                    Beneficios = "Elimina sarro, hongos y bacterias.",
                    Precauciones = "No combinar en exceso; reacción efervescente puede ser irritante.",
                },
                new TipitemModel
                {
                    Combinacion = "14. Aceite + bicarbonato   👈",
                    Uso = "Eliminación de grasa en manos",
                    ModoUso = "Mezclar y frotar suavemente durante 2 min.",
                    Beneficios = "Remueve grasa sin dañar la piel.",
                    Precauciones = "Evitar contacto con heridas abiertas.",
                    Fondo = "#E74C3C"
                },
                new TipitemModel
                {
                    Combinacion = "15. Vinagre + agua caliente + jabón líquido   👈",
                    Uso = "Limpieza de pisos",
                    ModoUso = "Mezclar y aplicar con trapeador, no enjuagar.",
                    Beneficios = "Deja pisos limpios y desinfectados.",
                    Precauciones = "Evitar en pisos de madera sin sellar.",
                }

            };
        }
    }

    public class TipitemModel
    {
        public string Combinacion { get; set; } = string.Empty;
        public string Uso { get; set; } = string.Empty;
        public string ModoUso { get; set; } = string.Empty;
        public string Beneficios { get; set; } = string.Empty;
        public string Precauciones { get; set; } = string.Empty;
        public string Fondo { get; set; } = "#044680";
    }
}
