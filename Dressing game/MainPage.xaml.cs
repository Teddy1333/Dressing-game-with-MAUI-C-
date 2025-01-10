using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using Dressing_game.Resources.Data;
using Dressing_game.Resources.Models;

namespace Dressing_game
{
    public partial class MainPage : ContentPage
    {
        private Button lastSelectedButton;
        private List<Theme> themes;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnItemClicked(object sender, EventArgs e)
        {
            var selectedButton = sender as Button;

            if (lastSelectedButton != null)
            {
                lastSelectedButton.BackgroundColor = Colors.RoyalBlue; // Reset previous selection
                lastSelectedButton.TextColor = Colors.White;
            }

            selectedButton.BackgroundColor = Colors.MediumVioletRed; // Highlight selected button
            selectedButton.TextColor = Colors.White;

            lastSelectedButton = selectedButton; // Track the current selection
        }
    }
}
