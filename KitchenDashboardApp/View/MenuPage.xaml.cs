using KitchenDashboardApp.ViewModel;

namespace KitchenDashboardApp.View;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}