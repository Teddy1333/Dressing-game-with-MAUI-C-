using Microsoft.Maui.Controls;

namespace Dressing_game
{
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private async void OnPlayClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnHowToPlayClicked(object sender, EventArgs e)
        {
            await DisplayAlert("How to play", "Dress up is a children's game in which clothing are put on a doll. The aim of the game is to create the style, including accessories that you think the doll will wear on a given theme\n1. Click on the Play button. \n2. Choose an item from the menu.\n3. Make your own style.\n4. Press the button down bellow to finish the game and check your score.\n5. Repeat until you are done.", "OK");
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}