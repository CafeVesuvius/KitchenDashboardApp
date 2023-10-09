using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public bool isActive { get; set; }
        public DateTime ChangedDate { get; set; }
        [JsonProperty("menuItems")]
        public List<MenuItem> MenuItems { get; set; }
    }
}
