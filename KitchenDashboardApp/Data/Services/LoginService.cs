using KitchenDashboardApp.Model.LoginModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Data.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoginResponse> Authenticate(LoginRequest loginRequest)
        {
            using(var client  = new HttpClient())
            {
                string loginRequestJson = JsonConvert.SerializeObject(loginRequest);
                var response = client.PostAsync("http://10.130.54.46:2000/api/Authentication",
                    new StringContent(loginRequestJson, Encoding.UTF8, "application/json"));

                if(response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Result.Content.ReadAsStringAsync();
                    return new LoginResponse
                    {
                        Token = json,
                    };
                }
                else { return null; }
            }
        }
    }
}
