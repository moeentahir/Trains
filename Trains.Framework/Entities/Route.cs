using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class Route
    {
        public Town Destination { get; set; }

        public int Distance { get; set; }

        public override string ToString() => $"{Destination} {Distance}";
    }
}
