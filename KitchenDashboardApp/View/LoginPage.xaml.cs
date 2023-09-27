using KitchenDashboardApp.ViewModel;

namespace KitchenDashboardApp.View;

public partial class LoginPage : ContentPage
{

	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}