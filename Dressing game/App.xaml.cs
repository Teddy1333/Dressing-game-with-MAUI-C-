namespace Dressing_game
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // Wrapping in NavigationPage
        }

       
    }
}