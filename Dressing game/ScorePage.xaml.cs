using Microsoft.Maui.Controls;
using Dressing_game.Resources.Models;
using System.Collections.Generic;

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

            if (score >= CurrentTheme.RequiredItems.Count * CurrentTheme.PointsPerItem)
            {
                DisplayAlert("Congratulations", $"You win the {CurrentTheme.Name} challenge!", "OK");
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
                if (theme.RequiredItems.Contains(item))
                {
                    score += theme.PointsPerItem;
                }
            }

            return score;
        }
    }
}
