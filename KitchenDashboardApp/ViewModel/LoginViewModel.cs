using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KitchenDashboardApp.Controllers;
using KitchenDashboardApp.Data.Services;
using KitchenDashboardApp.Model;
using KitchenDashboardApp.Model.LoginModels;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenDashboardApp.Model.UserBasicInfo;

namespace KitchenDashboardApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {

        [ObservableProperty]
        string username;
        [ObservableProperty]
        string password;

        readonly ILoginService _loginService;
        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [RelayCommand]
        async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                var response = await _loginService.Authenticate(new LoginRequest
                    {
                        Username = Username, 
                        Password = Password,                
                    });

                if(response != null)
                {
                    response.UserBasicInfo = new UserBasicInfo
                    {
                        Username = Username,
                        RoleId = (int)RoleDetails.Chef,
                        RoleName = "Køkken Arbejder"
                    };

                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }

                    await SecureStorage.SetAsync(nameof(App.Token), response.Token);

                    string userDetailstr = JsonConvert.SerializeObject(response.UserBasicInfo);
                    Preferences.Set(nameof(App.UserDetails), userDetailstr);
                    App.UserDetails = response.UserBasicInfo;
                    App.Token = response.Token;
                    await AppConstant.AddFloutMenusDetails();
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid User Name Or Password", "Invalid User Name Or Password", "Ok");
                }




            }
        }
    }
}
