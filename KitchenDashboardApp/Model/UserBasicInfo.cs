using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class UserBasicInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public enum RoleDetails
        {
            Chef,
            Waiter,
            Other,
        }
    }
}
