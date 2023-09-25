using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KitchenDashboardApp.Data;
using KitchenDashboardApp.Model;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDashboardApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Order> orders;

        [ObservableProperty]
        bool isRefreshing;

        System.Timers.Timer refreshTimer;

        public MainViewModel() 
        { 
            orders = new ObservableCollection<Order>();
            _ = Refresh();
            InitTimer();
        }

        public void InitTimer()
        {
            refreshTimer = new System.Timers.Timer(10000);
            refreshTimer.Elapsed += timer_Elapsed;
            refreshTimer.AutoReset = true;
            refreshTimer.Enabled = true;
        }
        private async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            IsRefreshing = !IsRefreshing;
            if (IsRefreshing)
            {
                await Refresh();
            }
        }

        [RelayCommand]
        async Task Refresh()
        {
            if (IsRefreshing)
            {
                try
                {
                    Orders.Clear();
                    var GetOrders = await APIAcess.GetOrders();
                    Orders = new ObservableCollection<Order>(GetOrders as List<Order>);
                }
                finally { IsRefreshing = false; }
            }
        }

        [RelayCommand]
        async Task OrderCompleted(Order order)
        {
            try
            {
                refreshTimer.Stop();
                order.Completed = true;
                await APIAcess.OrderCompleted(order);
            }
            finally { refreshTimer.Start(); }
        }
    }
}
