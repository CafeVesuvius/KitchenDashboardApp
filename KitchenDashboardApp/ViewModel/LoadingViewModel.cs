using CommunityToolkit.Mvvm.ComponentModel;
using KitchenDashboardApp.Controllers;
using KitchenDashboardApp.Model;
using KitchenDashboardApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static KitchenDashboardApp.Model.UserBasicInfo;

namespace KitchenDashboardApp.ViewModel
{
    public partial class LoadingViewModel : ObservableObject
    {
        public LoadingViewModel()
        {
            ChechUserLoginDetails();
        }

        async void ChechUserLoginDetails()
        {
            string userDetails = Preferences.Get(nameof(App.UserDetails), "");

            if (string.IsNullOrWhiteSpace(userDetails))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var tokenDetail = await SecureStorage.GetAsync(nameof(App.Token));

                var hanlder = new JwtSecurityTokenHandler();
                var jsonToken = hanlder.ReadToken(tokenDetail) as JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    await Shell.Current.DisplayAlert("User session expired", "Login again to continue","Ok");
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    var userInfo = JsonConvert.DeserializeObject<UserBasicInfo>(userDetails);
                    App.UserDetails = userInfo;
                    App.Token = tokenDetail;
                    await AppConstant.AddFloutMenusDetails();
                }
            }
        }
    }
}
