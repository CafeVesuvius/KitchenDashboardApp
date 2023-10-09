using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KitchenDashboardApp.Data;
using KitchenDashboardApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.ViewModel
{
    public partial class MenuViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Menu> menus;

        [ObservableProperty]
        bool isRefreshing = true;

        //System.Timers.Timer refreshTimer;

        public MenuViewModel()
        {
            Menus = new ObservableCollection<Menu>();
            _ = Refresh();

        }


        [RelayCommand]
        async Task Refresh()
        {
            if (IsRefreshing)
            {
                try
                {
                    Menus.Clear();
                    var GetMenus = await APIAcess.GetActiveMenu();
                    Menus = new ObservableCollection<Menu>(GetMenus as List<Menu>);
                }
                finally { IsRefreshing = false; }
            }
            else
            {
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task UpdateMenuItem(Model.MenuItem menuItem)
        {
            try
            {
                Menus.Clear();
                menuItem.Active = !menuItem.Active;
                await APIAcess.MenuItemUpdate(menuItem);
            } finally { IsRefreshing = true; Refresh(); }
        }
    }
}
