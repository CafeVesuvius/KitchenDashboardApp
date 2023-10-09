using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        [JsonProperty("isActive")]
        public bool Active { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string ActiveString { get; set; }
        public string ImagePath { get; set; }
        public int MenuId { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Active) { ActiveString = "Active"; } else { ActiveString = "Inactive"; }
        }
    }
}
