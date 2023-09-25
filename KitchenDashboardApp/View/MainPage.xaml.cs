using KitchenDashboardApp.ViewModel;

namespace KitchenDashboardApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}