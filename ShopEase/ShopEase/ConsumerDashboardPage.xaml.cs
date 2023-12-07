namespace ShopEase;

public partial class ConsumerDashboardPage : ContentPage
{
	public ConsumerDashboardPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        full_name.Text = "Welcome, " + AppShell.active_user.Name;
        unique_items.Text = "10";
        total_orders.Text = "10";
        total_purchases.Text = "$10";
    }

    private async void logout_Clicked(object sender, EventArgs e)
    {
        AppShell.active_user = null;
        await DisplayAlert("Message", "Thanks for visiting, See you soon!", "Ok");
        ((AppShell)App.Current.MainPage).manage_tabs();
        await Shell.Current.GoToAsync("///LoginPage");
    }
}