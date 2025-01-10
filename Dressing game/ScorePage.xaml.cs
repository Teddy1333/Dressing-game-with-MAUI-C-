using Microsoft.Maui.Controls;

namespace Dressing_game
{
    public partial class ScorePage : ContentPage
    {
        public ScorePage()
        {
            InitializeComponent();
        }

        private void OnCalculateScoreClicked(object sender, EventArgs e)
        {
            int score = CalculateScore();
            ScoreLabel.Text = $"Your Score: {score}";
        }

        private int CalculateScore()
        {
            return new Random().Next(0, 101); // For demonstration, returning a random score
        }
    }
}
