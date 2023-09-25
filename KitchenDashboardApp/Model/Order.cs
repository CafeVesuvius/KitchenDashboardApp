﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool Completed { get; set; }
        [JsonProperty("orderLines")]
        public List<OrderLine> OrderLines { get; set; }
    }
}