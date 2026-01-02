// Copyright Slav Povstianoj 2026

using Microsoft.Extensions.Logging;
using SettingsPlayground.Services;

namespace SettingsPlayground
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // Register services
            builder.Services.AddSingleton<SettingsStore>();
            builder.Services.AddSingleton<SettingsState>();
            builder.Services.AddSingleton<ImportExportService>();
            builder.Services.AddSingleton<ThemeService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
