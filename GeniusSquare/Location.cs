using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeniusSquare
{
    public class Location
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public override string ToString()
        {
            return $"{(char)('A' + Row)}{Column + 1}";
        }

        public void FromString(string coordinates)
        {
            Match m = Regex.Match(coordinates, "([A-Z])([0-9])");
            if (m.Success)
            {
                Row = m.Groups[1].Value[0] - 'A';
                Column = int.Parse(m.Groups[2].Value) - 1;
            }
        }
    }
}
