using KitchenDashboardApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
                BaseAddress = new Uri(ApiBaseUrl),
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<List<Order>> GetOrders()
        {
            try
            {
                var json = await client.GetStringAsync(ApiBaseUrl + "order/incomplete");
                List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(json, new JsonSerializerSettings
                {
                    DateFormatString = "HH:mm"
                });
                return orders;
            } catch (Exception ex)
            {
                return null;
            }

        }

        public static async Task OrderCompleted(Order order)
        {
            try
            {
                var json = JsonConvert.SerializeObject(order);
                HttpResponseMessage response = await client.PutAsync($"order/{order.Id}", 
                    new StringContent(json, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
            } catch (Exception ex) { }
        }
        public static async Task OrderDeleted(Order order)
        {
            try
            {
                var json = JsonConvert.SerializeObject(order);
                HttpResponseMessage response = await client.DeleteAsync($"order/{order.Id}");
            } catch (Exception ex) { }
        }
    }
}
