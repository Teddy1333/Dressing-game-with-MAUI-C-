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
            themes = ThemeData.GetThemes();
            LoadAllItems();  // Load all items from the themes
        }

        // Load all items into their respective categories
        private void LoadAllItems()
        {
            // Clear existing wardrobe items in each category
            TopsGrid.Children.Clear();
            BottomsGrid.Children.Clear();
            ShoesGrid.Children.Clear();
            AccessoriesGrid.Children.Clear();

            // Iterate through each theme and its items
            foreach (var theme in themes)
            {
                foreach (var item in theme.RequiredItems)
                {

                    // Categorize items dynamically based on their name
                    if (item == "Puffy Jacket" || item == "Tank Top" || item == "Leather Jacket") // Tops
                        AddItemToCategory(TopsGrid, item);
                    else if (item == "Jeans" || item == "Black Skirt" || item == "Shorts") // Bottoms
                        AddItemToCategory(BottomsGrid, item);
                    else if (item == "Espadrils" || item == "Black High Heels" || item == "Boots") // Shoes
                        AddItemToCategory(ShoesGrid, item);
                    else // Accessories
                        AddItemToCategory(AccessoriesGrid, item);
                }
            }
        }

        // Add item to a specific category
        private void AddItemToCategory(Grid categoryGrid, string itemName)
        {
            int column = categoryGrid.Children.Count % 5; // Ensure 5 items per row
            int row = categoryGrid.Children.Count / 5;

            var button = new Button
            {
                Text = itemName,
                BackgroundColor = Colors.RoyalBlue,
                TextColor = Colors.White
            };
            button.Clicked += OnItemClicked;

            // Set the row and column for the button
            categoryGrid.Children.Add(button);
            Grid.SetColumn(button, column);
            Grid.SetRow(button, row);
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
