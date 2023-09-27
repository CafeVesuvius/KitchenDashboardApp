using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KitchenDashboardApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.ViewModel
{
    public partial class AppShellViewModel : ObservableObject
    {
        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
            var OrderBoardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(MainPage)).FirstOrDefault();
            if (OrderBoardInfo != null) AppShell.Current.Items.Remove(OrderBoardInfo);

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
