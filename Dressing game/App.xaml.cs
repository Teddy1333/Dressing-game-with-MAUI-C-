namespace Dressing_game
{
    public partial class App : Application
    {
        public static string ConnectionString = "Server=DESKTOP-TH20QIU;Database=DressingGame;Trusted_Connection=True;";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FrontPage());
        }

    }
}