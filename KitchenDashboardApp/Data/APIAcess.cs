using KitchenDashboardApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Data
{
    public class APIAcess
    {
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000/api/";
        static readonly HttpClient client;

        static APIAcess()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public static async Task<List<Order>> GetOrders()
        {
            var json = await client.GetStringAsync(ApiBaseUrl+"orders");
            var orders = JsonConvert.DeserializeObject<List<Order>>(json);
            return orders;
        }

        public static async Task OrderCompleted(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var response = await client.PutAsJsonAsync($"Order/{order.Id}", json);
        }

    }
}
