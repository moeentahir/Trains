using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class TravelLog
    {
        public string PathSoFar { get; set; }

        public int NumberOfStops { get; set; }

        public int DistanceTravelled { get; set; }

        public override string ToString() => $"Path: {PathSoFar} | Distance: {DistanceTravelled} | Stops: {NumberOfStops}";

    }
}
