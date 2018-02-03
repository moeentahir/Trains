using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class TravelDistanceGreaterThanOrEqualTo30Rule : ITravelRule
    {
        public bool IsMatch(TravelLog ticket) => ticket.DistanceTravelled >= 30;
    }
}
