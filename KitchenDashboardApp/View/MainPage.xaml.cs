﻿using KitchenDashboardApp.ViewModel;

namespace KitchenDashboardApp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}