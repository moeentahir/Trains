using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class GreaterThanThreeStopsRule : ITravelRule
    {
        public bool IsMatch(TravelLog ticket) => ticket.StopsTravelled > 3;
    }
}
