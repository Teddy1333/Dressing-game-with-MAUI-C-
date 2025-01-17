using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dressing_game.Resources.Models.Enums;

namespace Dressing_game.Resources.Models
{
    public class Themes
    {
        public string Name { get; set; }
        public List<Enum> RequiredItems { get; set; }
        public int PointsPerItem { get; set; }
    }

}
