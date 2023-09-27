using KitchenDashboardApp.ViewModel;

namespace KitchenDashboardApp.View;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}