using KitchenDashboardApp.Model;
using KitchenDashboardApp.View;

namespace KitchenDashboardApp
{
    public partial class App : Application
    {
        public static UserBasicInfo UserDetails;
        public static string Token;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            //Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        }
    }
}