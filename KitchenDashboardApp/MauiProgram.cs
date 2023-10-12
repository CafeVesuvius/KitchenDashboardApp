using KitchenDashboardApp.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using KitchenDashboardApp.View;
using KitchenDashboardApp.Data.Services;

namespace KitchenDashboardApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();


            // Services
            builder.Services.AddSingleton<ILoginService, LoginService>();

            // Dependency service for views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<MenuPage>();

            // Dependecy service for viewmodels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoadingViewModel>();
            builder.Services.AddSingleton<MenuViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}