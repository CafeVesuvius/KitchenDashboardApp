using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [JsonProperty("menuItem")]
        public MenuItem MenuItem { get; set; }
    }
}
