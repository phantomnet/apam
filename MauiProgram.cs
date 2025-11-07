using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.Logging;

namespace apam
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIconsRegular");
                });

            builder.RegisterAndroidServices();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

    
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAndroidServices(this MauiAppBuilder builder)
        {
#if ANDROID

        builder.Services.AddSingleton<IAutoCallService, AutoCallService>();
        builder.Services.AddSingleton<ISpeechToText, SpeechToTextService>();

#endif
        }
    }
}