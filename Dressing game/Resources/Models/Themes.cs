using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_game.Resources.Models
{
    public class Theme
    {
        public string Name { get; set; }
        public List<string> RequiredItems { get; set; }
        public int PointsPerItem { get; set; }
    }

}
