using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    /// <summary>
    /// This rules returns true if you have travelled more than double of all the roads in the map
    /// </summary>
    public class MoreThanTwiceRoutesCoveredRule : ITravelRule
    {
        public bool IsMatch(TravelLog ticket) => ticket.StopsTravelled > (ticket.Map.TotalRoutes * 2);
    }
}
