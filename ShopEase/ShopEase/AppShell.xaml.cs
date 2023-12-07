namespace ShopEase
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            splash_loading_completed(false);
        }

        public void switch_splash_screen()
        {
            splash_loading_completed(true);
            welcome_splash_screen.IsVisible = false;
            Shell.Current.GoToAsync("///LoginPage");
        }

        public void splash_loading_completed(bool completed)
        {
            login_page.IsVisible = completed;
            signup_page.IsVisible = completed;
        }
    }
}