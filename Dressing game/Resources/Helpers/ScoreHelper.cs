using Dressing_game.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dressing_game.Resources.Helpers
{
    public static class ScoreHelper
    {
        public static int CalculateScore(List<string> selectedItems, Themes theme)
        {
            if (theme == null || selectedItems == null) return 0;

            int score = 0;

            foreach (var item in selectedItems)
            {
                string itemName = item.Replace(" ", "_");

                bool itemMatched = false;

                foreach (var requiredItem in theme.RequiredItems)
                {
                    string enumName = requiredItem.ToString();

                    if (enumName.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                    {
                        score += theme.PointsPerItem;
                        itemMatched = true;
                        break;
                    }
                }

                if (!itemMatched)
                {
                    Console.WriteLine($"Item not found in theme's required items: {item}");
                }
            }

            return score;
        }
    }
}
