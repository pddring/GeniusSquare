using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusSquare
{
    public class Dice
    {
        List<Location> locations = new List<Location>();
        Random r = new Random();
        public Dice(string[] locations) { 
            foreach(string location in locations)
            {
                Location l = new Location();
                l.FromString(location);
                this.locations.Add(l);
            }
        }

        public Location Roll()
        {
            return locations[r.Next(0, locations.Count)];
        }
    }
}
