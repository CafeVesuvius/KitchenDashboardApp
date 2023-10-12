using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model.LoginModels
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserBasicInfo UserBasicInfo { get; set; }

    }
}
