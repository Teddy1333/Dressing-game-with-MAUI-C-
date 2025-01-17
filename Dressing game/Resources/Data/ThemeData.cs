using System;
using System.Collections.Generic;
using Dressing_game.Resources.Models;
using static Dressing_game.Resources.Models.Enums;

namespace Dressing_game.Resources.Data
{
    public static class ThemeData
    {
        public static List<Themes> GetThemes()
        {
            return new List<Themes>
            {
                new Themes
                {
                    Name = "Winter",
                    RequiredItems = new List<Enum>
                    {
                        WinterItems.Sweater,
                        WinterItems.Jeans,
                        WinterItems.Skates,
                        WinterItems.Jacket
                    },
                    PointsPerItem = 10
                },
                new Themes
                {
                    Name = "Summer",
                    RequiredItems = new List<Enum>
                    {
                        SummerItems.Shirt,
                        SummerItems.Shorts,
                        SummerItems.Espadrils,
                        SummerItems.Glasses
                    },
                    PointsPerItem = 10
                },
                new Themes
                {
                    Name = "Rock Concert",
                    RequiredItems = new List<Enum>
                    {
                        RockConcertItems.Cutoff,
                        RockConcertItems.Skirt,
                        RockConcertItems.Heels,
                        RockConcertItems.Handbag
                    },
                    PointsPerItem = 10
                }
            };
        }
    }
}
