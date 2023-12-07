namespace ShopEase;

public partial class LoginPage : ContentPage
{
    api_handler api_service = new api_handler();

    public LoginPage()
	{
		InitializeComponent();
	}

    private void goto_sign_up(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("///SignupPage");
    }

    private void reset_Clicked(object sender, EventArgs e)
    {
        email.Text = string.Empty;
        password.Text = string.Empty;
        error.Text = string.Empty;
    }

    private string filter_input(string text)
    {
        text = text.Trim();
        text = text.ToUpper();
        text = text.Replace("\"", "");
        text = text.Replace("\'", "");
        return text;
    }

    private async void login_Clicked(object sender, EventArgs e)
    {
        error.Text = "Please wait, thank you!";

        string login_email = filter_input(email.Text);
        string login_password = filter_input(password.Text);

        if (login_email == "" || login_password == "")
        {
            error.Text = "Both email and password are required for login!";
        }
        else
        {
            User login_user = await api_service.CheckUserLogin(login_email, login_password);
            if (login_user == null) { error.Text = "Oops, something went wrong! Try again later!"; }
            else if (login_user.Id == 0) { error.Text = "Sorry, login details not found! Signup if new user!"; }
            else
            {
                reset_Clicked(reset, new EventArgs());
                AppShell.active_user = login_user;
                error.Text = "Login successfull!";
            }
        }
    }
}