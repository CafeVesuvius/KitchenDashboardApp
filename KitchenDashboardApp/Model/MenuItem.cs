using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.Model
{
    public class MenuItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Active { get; set; }
        public string ImagePath { get; set; }
        public int MenuId { get; set; }
    }
}
