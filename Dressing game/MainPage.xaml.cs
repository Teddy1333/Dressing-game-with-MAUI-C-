using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq; // For random selection
using Dressing_game.Resources.Data;
using Dressing_game.Resources.Models;

namespace Dressing_game
{
    public partial class MainPage : ContentPage
    {
        private Button lastSelectedTop;
        private Button lastSelectedBottom;
        private Button lastSelectedShoe;
        private Button lastSelectedAccessory;
        private List<Theme> themes;

        public MainPage()
        {
            InitializeComponent();
            themes = ThemeData.GetThemes();
            RandomizeTheme(); // Randomize the theme when the page loads
            LoadAllItems();  // Load all items from the themes
        }

        // Randomize the theme and update the label
        private void RandomizeTheme()
        {
            Random random = new Random();
            // Select a random theme from the list
            Theme selectedTheme = themes[random.Next(themes.Count)];

            // Update the ThemeLabel to display the selected theme's name
            ThemeLabel.Text = $"Theme: {selectedTheme.Name}";
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
                        AddItemToCategory(TopsGrid, item, "top");
                    else if (item == "Jeans" || item == "Black Skirt" || item == "Shorts") // Bottoms
                        AddItemToCategory(BottomsGrid, item, "bottom");
                    else if (item == "Espadrils" || item == "Black High Heels" || item == "Boots") // Shoes
                        AddItemToCategory(ShoesGrid, item, "shoe");
                    else // Accessories
                        AddItemToCategory(AccessoriesGrid, item, "accessory");
                }
            }
        }

        // Add item to a specific category
        private void AddItemToCategory(Grid categoryGrid, string itemName, string category)
        {
            int column = categoryGrid.Children.Count % 5; // Ensure 5 items per row
            int row = categoryGrid.Children.Count / 5;

            var button = new Button
            {
                Text = itemName,
                BackgroundColor = Colors.RoyalBlue,
                TextColor = Colors.White
            };

            button.Clicked += (sender, e) => OnItemClicked(sender, e, category);

            // Set the row and column for the button
            categoryGrid.Children.Add(button);
            Grid.SetColumn(button, column);
            Grid.SetRow(button, row);
        }

        // Handle item selection and ensure only one button per category is highlighted
        private void OnItemClicked(object sender, EventArgs e, string category)
        {
            var selectedButton = sender as Button;

            switch (category)
            {
                case "top":
                    ResetSelection(ref lastSelectedTop);
                    lastSelectedTop = selectedButton;
                    break;

                case "bottom":
                    ResetSelection(ref lastSelectedBottom);
                    lastSelectedBottom = selectedButton;
                    break;

                case "shoe":
                    ResetSelection(ref lastSelectedShoe);
                    lastSelectedShoe = selectedButton;
                    break;

                case "accessory":
                    ResetSelection(ref lastSelectedAccessory);
                    lastSelectedAccessory = selectedButton;
                    break;
            }

            // Highlight the selected button
            selectedButton.BackgroundColor = Colors.MediumVioletRed;
            selectedButton.TextColor = Colors.White;
        }

        // Reset the background color of the previously selected button
        private void ResetSelection(ref Button lastSelectedButton)
        {
            if (lastSelectedButton != null)
            {
                lastSelectedButton.BackgroundColor = Colors.RoyalBlue; // Reset previous selection
                lastSelectedButton.TextColor = Colors.White;
            }
        }
    }
}
