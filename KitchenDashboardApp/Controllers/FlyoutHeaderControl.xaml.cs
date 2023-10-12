namespace KitchenDashboardApp.Controllers;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.UserDetails != null)
		{
			lblUerName.Text = App.UserDetails.Username;
		}
	}
}