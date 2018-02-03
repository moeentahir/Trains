using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public struct TravelLog
    {
        public string RouteCovered { get; set; }

        public int StopsTravelled { get; set; }

        public int DistanceTravelled { get; set; }

        public Map Map { get; set; }

        public override string ToString() => $"Path: {RouteCovered} | Distance: {DistanceTravelled} | Stops: {StopsTravelled}";

    }
}
