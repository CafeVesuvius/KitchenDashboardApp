using KitchenDashboardApp.View;
using KitchenDashboardApp.ViewModel;
using static KitchenDashboardApp.Model.UserBasicInfo;

namespace KitchenDashboardApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();

        }
    }
}