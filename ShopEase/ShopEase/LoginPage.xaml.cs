namespace ShopEase;

public partial class LoginPage : ContentPage
{
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

    private void login_Clicked(object sender, EventArgs e)
    {
        string login_email = filter_input(email.Text);
        string login_password = filter_input(password.Text);

        if (login_email == "" || login_password == "")
        {
            error.Text = "Both email and password are required for login!";
        }
        else
        {

        }
    }
}