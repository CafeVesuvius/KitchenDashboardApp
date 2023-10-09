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
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        [JsonProperty("isCompleted")]
        public bool? Completed { get; set; }
        [JsonProperty("orderLines")]
        public List<OrderLine> OrderLines { get; set; }

        public string? CreatedTimeOnly { get; set; }

        [Newtonsoft.Json.JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            DateTime date = (DateTime)_additionalData["createdDate"];

            Created = date;
            CreatedTimeOnly = date.ToString("HH:mm");
        }

    }
}
 