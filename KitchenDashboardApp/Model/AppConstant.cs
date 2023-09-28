using KitchenDashboardApp.Controllers;
using KitchenDashboardApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenDashboardApp.Model.UserBasicInfo;

namespace KitchenDashboardApp.Model
{
    public class AppConstant
    {

        public async static Task AddFloutMenusDetails()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

            var mainPage = AppShell.Current.Items.Where(f => f.Route == nameof(MainPage)).FirstOrDefault();
            if(mainPage != null) AppShell.Current.Items.Remove(mainPage);

            var menuPage = AppShell.Current.Items.Where(f => f.Route == nameof(MenuPage)).FirstOrDefault();
            if (menuPage != null) AppShell.Current.Items.Remove(menuPage);


            if (App.UserDetails.RoleId == (int)RoleDetails.Chef)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Order Page",
                    Route = "MainPage",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                            {
                                new ShellContent
                                {
                                    Title = "Køkken Dashboard",
                                    ContentTemplate = new DataTemplate(typeof(MainPage)),
                                },
                                new ShellContent
                                {
                                    Title = "Menu Oversigt",
                                    ContentTemplate = new DataTemplate(typeof(MenuPage)),
                                },
                            }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                }
            }
        }
    }
}
