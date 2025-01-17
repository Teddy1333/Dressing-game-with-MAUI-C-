using Microsoft.Maui.Controls;
using Dressing_game.Resources.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dressing_game
{
    public partial class ScorePage : ContentPage
    {
        private Theme CurrentTheme;
        private List<string> SelectedItems;

        public ScorePage(Theme selectedTheme, List<string> selectedItems)
        {
            InitializeComponent();
            CurrentTheme = selectedTheme;
            SelectedItems = selectedItems;

            ThemeLabel.Text = $"Theme: {CurrentTheme.Name}";
            SelectedItemsLabel.Text = $"Selected Items: {string.Join(", ", SelectedItems)}"; // Display selected items
        }

        private void OnCalculateScoreClicked(object sender, EventArgs e)
        {
            if (CurrentTheme == null)
            {
                DisplayAlert("Error", "No theme selected!", "OK");
                return;
            }

            int score = CalculateScore(SelectedItems, CurrentTheme);
            ScoreLabel.Text = $"Your Score: {score}";

            int maxScore = CurrentTheme.RequiredItems.Count * CurrentTheme.PointsPerItem;

            if (score == maxScore)
            {
                DisplayAlert("Perfect!", $"You nailed the {CurrentTheme.Name} challenge!", "OK");
            }
            else if (score >= maxScore * 0.75)
            {
                DisplayAlert("Almost There!", $"You did well in the {CurrentTheme.Name} challenge, but there's room for improvement.", "OK");
            }
            else if (score >= maxScore * 0.5)
            {
                DisplayAlert("Not Bad!", $"You completed the {CurrentTheme.Name} challenge, but you missed some key items.", "OK");
            }
            else
            {
                DisplayAlert("Try Again", $"You need more points to win the {CurrentTheme.Name} challenge!", "OK");
            }
        }


        private int CalculateScore(List<string> selectedItems, Theme theme)
        {
            if (theme == null) return 0;

            int score = 0;

            foreach (var item in selectedItems)
            {
                if (theme.RequiredItems.Any(enumItem => enumItem.ToString() == item))
                {
                    score += theme.PointsPerItem;
                }
            }

            return score;
        }

    }
}
