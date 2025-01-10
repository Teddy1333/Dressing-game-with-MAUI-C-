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
                Name = "Winter",
                RequiredItems = new List<string> { "Puffy Jacket", "Jeans", "Boots", "Winter Hat" },
                PointsPerItem = 10
            },
            new Theme
            {
                Name = "Summer",
                RequiredItems = new List<string> { "Tank Top", "Shorts", "Espadrils", "Sun Glasses" },
                PointsPerItem = 15
            },
            new Theme
            {
                Name = "Rock Concert",
                RequiredItems = new List<string> { "Leather Jacket", "Black Skirt", "Black High Heels", "Bass Guitar" },
                PointsPerItem = 20
            }
        };
        }
    }

}
