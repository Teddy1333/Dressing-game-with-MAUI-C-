using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dressing_game.Resources.Models;

namespace Dressing_game.Resources.Data
{
    

    public static class ThemeData
    {
        public static List<Theme> GetThemes()
        {
            return new List<Theme>
        {
            new Theme
            {
                Name = "Casual Fan Meet",
                RequiredItems = new List<string> { "T-Shirt", "Jeans", "Sneakers" },
                PointsPerItem = 10
            },
            new Theme
            {
                Name = "Stage Performance",
                RequiredItems = new List<string> { "Glitter Top", "Leather Pants", "High Heels" },
                PointsPerItem = 15
            }
        };
        }
    }

}
