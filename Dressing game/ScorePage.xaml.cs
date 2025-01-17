using Microsoft.Maui.Controls;
using Dressing_game.Resources.Models;
using Dressing_game.Resources.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Dressing_game.Resources.Helpers;

namespace Dressing_game
{
    public partial class ScorePage : ContentPage
    {
        private Themes CurrentTheme;
        private List<string> SelectedItems;

        public ScorePage(Themes selectedTheme, List<string> selectedItems)
        {
            InitializeComponent();
            CurrentTheme = selectedTheme;
            SelectedItems = selectedItems;

            ThemeLabel.Text = $"Theme: {CurrentTheme.Name}";
            SelectedItemsLabel.Text = $"Selected Items: {string.Join(", ", SelectedItems)}";
        }

        private void OnCalculateScoreClicked(object sender, EventArgs e)
        {
            if (CurrentTheme == null)
            {
                DisplayAlert("Error", "No theme selected!", "OK");
                return;
            }

            int score = ScoreHelper.CalculateScore(SelectedItems, CurrentTheme);

            ScoreLabel.Text = $"Your Score: {score}";

            int maxScore = CurrentTheme.RequiredItems.Count * CurrentTheme.PointsPerItem;

            string message = score == maxScore
                ? $"You nailed the {CurrentTheme.Name} challenge!"
                : score >= maxScore * 0.75
                    ? $"You did well in the {CurrentTheme.Name} challenge, but there's room for improvement."
                    : score >= maxScore * 0.5
                        ? $"You completed the {CurrentTheme.Name} challenge, but you missed some key items."
                        : $"You need more points to win the {CurrentTheme.Name} challenge!";

            DisplayAlert(score == maxScore ? "Perfect!" : score >= maxScore * 0.75 ? "Almost There!" : score >= maxScore * 0.5 ? "Not Bad!" : "Try Again", message, "OK");

            var scoreRepository = new ScoreRepository();
            scoreRepository.SaveScore(score);

            DisplayAlert("Score Saved", "Your score has been saved successfully!", "OK");
        }
    }
}
