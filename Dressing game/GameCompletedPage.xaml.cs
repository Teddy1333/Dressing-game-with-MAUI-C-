namespace Dressing_game;

public partial class GameCompletedPage : ContentPage
{
	public GameCompletedPage()
	{
		InitializeComponent();
	}

	public async void OnPlayAgainClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new FrontPage());
    }

}