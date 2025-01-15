using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
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
        private Theme selectedTheme;

        private string selectedTop;
        private string selectedBottom;
        private string selectedShoe;
        private string selectedAccessory;

        public MainPage()
        {
            InitializeComponent();
            themes = ThemeData.GetThemes();
            RandomizeTheme();
            LoadAllItems();
        }

        private void RandomizeTheme()
        {
            Random random = new Random();
            selectedTheme = themes[random.Next(themes.Count)];
            ThemeLabel.Text = $"Theme: {selectedTheme.Name}";
        }

        private void LoadAllItems()
        {
            TopsGrid.Children.Clear();
            BottomsGrid.Children.Clear();
            ShoesGrid.Children.Clear();
            AccessoriesGrid.Children.Clear();

            foreach (var theme in themes)
            {
                foreach (var item in theme.RequiredItems)
                {
                    if (item == "Leather Jacket" || item == "Tank Top" || item == "Puffy Jacket")
                        AddItemToCategory(TopsGrid, item, "top");
                    else if (item == "Jeans" || item == "Shorts" || item == "Black Skirt")
                        AddItemToCategory(BottomsGrid, item, "bottom");
                    else if (item == "Black High Heels" || item == "Espadrils" || item == "Boots")
                        AddItemToCategory(ShoesGrid, item, "shoe");
                    else
                        AddItemToCategory(AccessoriesGrid, item, "accessory");
                }
            }
        }

        private void AddItemToCategory(Grid categoryGrid, string itemName, string category)
        {
            int column = categoryGrid.Children.Count % 5;
            int row = categoryGrid.Children.Count / 5;

            var button = new Button
            {
                Text = itemName,
                BackgroundColor = Colors.RoyalBlue,
                TextColor = Colors.White
            };

            button.Clicked += (sender, e) => OnItemClicked(sender, e, category);

            categoryGrid.Children.Add(button);
            Grid.SetColumn(button, column);
            Grid.SetRow(button, row);
        }

        private void OnItemClicked(object sender, EventArgs e, string category)
        {
            var selectedButton = sender as Button;

            switch (category)
            {
                case "top":
                    ResetSelection(ref lastSelectedTop);
                    lastSelectedTop = selectedButton;
                    selectedTop = selectedButton.Text; // Store selected top
                    break;

                case "bottom":
                    ResetSelection(ref lastSelectedBottom);
                    lastSelectedBottom = selectedButton;
                    selectedBottom = selectedButton.Text; // Store selected bottom
                    break;

                case "shoe":
                    ResetSelection(ref lastSelectedShoe);
                    lastSelectedShoe = selectedButton;
                    selectedShoe = selectedButton.Text; // Store selected shoe
                    break;

                case "accessory":
                    ResetSelection(ref lastSelectedAccessory);
                    lastSelectedAccessory = selectedButton;
                    selectedAccessory = selectedButton.Text; // Store selected accessory
                    break;
            }

            selectedButton.BackgroundColor = Colors.MediumVioletRed;
            selectedButton.TextColor = Colors.White;
        }

        private void ResetSelection(ref Button lastSelectedButton)
        {
            if (lastSelectedButton != null)
            {
                lastSelectedButton.BackgroundColor = Colors.RoyalBlue;
                lastSelectedButton.TextColor = Colors.White;
            }
        }

        private async void OnGoToScorePageClicked(object sender, EventArgs e)
        {
            if (selectedTheme == null)
            {
                await DisplayAlert("Error", "No theme selected!", "OK");
                return;
            }

            var selectedItems = new List<string>
            {
                selectedTop,
                selectedBottom,
                selectedShoe,
                selectedAccessory
            };

            // Navigate to ScorePage with the selected items and theme
            await Navigation.PushAsync(new ScorePage(selectedTheme, selectedItems));
        }
    }
}
