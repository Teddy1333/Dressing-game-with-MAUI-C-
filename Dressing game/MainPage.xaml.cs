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

        private List<Themes> themes;
        private Themes selectedTheme;

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
                    if (item.ToString() == "Cutoff" || item.ToString() == "Shirt" || item.ToString() == "Sweater")
                        AddItemToCategory(TopsGrid, item.ToString(), "top");
                    else if (item.ToString() == "Jeans" || item.ToString() == "Shorts" || item.ToString() == "Skirt")
                        AddItemToCategory(BottomsGrid, item.ToString(), "bottom");
                    else if (item.ToString() == "Heels" || item.ToString() == "Espadrils" || item.ToString() == "Skates")
                        AddItemToCategory(ShoesGrid, item.ToString(), "shoe");
                    else
                        AddItemToCategory(AccessoriesGrid, item.ToString(), "accessory");
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
                    selectedTop = selectedButton.Text;

                    TopLayer.Source = $"{selectedButton.Text.Replace(" ", "_").ToLower()}.png";
                    TopLayer.IsVisible = true;
                    break;

                case "bottom":
                    ResetSelection(ref lastSelectedBottom);
                    lastSelectedBottom = selectedButton;
                    selectedBottom = selectedButton.Text;

                    BottomLayer.Source = $"{selectedButton.Text.Replace(" ", "_").ToLower()}.png";
                    BottomLayer.IsVisible = true;
                    break;

                case "shoe":
                    ResetSelection(ref lastSelectedShoe);
                    lastSelectedShoe = selectedButton;
                    selectedShoe = selectedButton.Text;

                    ShoeLayer.Source = $"{selectedButton.Text.Replace(" ", "_").ToLower()}.png";
                    ShoeLayer.IsVisible = true;
                    break;

                case "accessory":
                    ResetSelection(ref lastSelectedAccessory);
                    lastSelectedAccessory = selectedButton;
                    selectedAccessory = selectedButton.Text;

                    AccessoryLayer.Source = $"{selectedButton.Text.Replace(" ", "_").ToLower()}.png";
                    AccessoryLayer.IsVisible = true;
                    break;
            }

            selectedButton.BackgroundColor = Colors.HotPink;
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

            await Navigation.PushAsync(new ScorePage(selectedTheme, selectedItems));
        }
    }
}