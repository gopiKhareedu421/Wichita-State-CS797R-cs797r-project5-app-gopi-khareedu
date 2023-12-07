namespace ShopEase;

public partial class RetailerDashboardPage : ContentPage
{
	public RetailerDashboardPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        full_name.Text = "Welcome, " + AppShell.active_user.Name;
        user_joining_date.Text = " " + AppShell.active_user.JoiningDate.ToString("dd MMM, yyyy");
        unique_items.Text = "10";
        total_orders.Text = "10";
        pending_orders.Text = "10";
        total_sales.Text = "$10";
    }

    private async void logout_Clicked(object sender, EventArgs e)
    {
        AppShell.active_user = null;
        await DisplayAlert("Message", "Thanks for visiting, See you soon!", "Ok");
        ((AppShell)App.Current.MainPage).manage_tabs();
        await Shell.Current.GoToAsync("///LoginPage");
    }
}