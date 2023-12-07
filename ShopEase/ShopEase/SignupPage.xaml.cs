namespace ShopEase;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

    private void reset_Clicked(object sender, EventArgs e)
    {
        first_name.Text = string.Empty;
        last_name.Text = string.Empty;
        email.Text = string.Empty;
        mobile.Text = string.Empty;
        password.Text = string.Empty;
        confirm_password.Text = string.Empty;
    }

    private void goto_login(object sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("///LoginPage");
    }

    private string filter_input(string text)
    {
        text = text.Trim();
        text = text.ToUpper();
        text = text.Replace("\"", "");
        text = text.Replace("\'", "");
        return text;
    }

    private void signup_Clicked(object sender, EventArgs e)
    {
        string signup_first_name = filter_input(email.Text);
        string signup_last_name = filter_input(password.Text);
        string signup_email = filter_input(email.Text);
        string signup_mobile = filter_input(password.Text);
        string signup_password = filter_input(password.Text);
        string signup_confirm_password = filter_input(confirm_password.Text);
        string signup_user_type = (consumer.IsChecked) ? consumer.Value.ToString() : retailer.Value.ToString();

        if (signup_first_name == "" || signup_last_name == "" || signup_email == "" || signup_mobile == "" || signup_password == "" || signup_confirm_password == "")
        {
            error.Text = "All fields are required for signup!";
        }
        else if(signup_password != signup_confirm_password)
        {
            error.Text = "Signup password and confirm password didn't matched!";
        }
        else
        {

        }
    }

    private void name_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender == first_name) { first_name.Text = first_name.Text.Replace(" ", ""); }
        else if (sender == last_name) { last_name.Text = last_name.Text.Replace(" ", ""); }
        else if (sender == email) { email.Text = email.Text.Replace(" ", ""); }
        else if (sender == mobile) { mobile.Text = mobile.Text.Replace(" ", ""); }
        else if (sender == password) { password.Text = password.Text.Replace(" ", ""); }
        else if (sender == confirm_password) { confirm_password.Text = confirm_password.Text.Replace(" ", ""); }
    }
}