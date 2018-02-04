using System.Collections.Generic;

namespace Trains.Framework
{
    public interface IRouteFinder
    {
        List<TravelCard> FindAllRoutesBetween(Town origin, Town destination, ITravelRule stopTravelingRule, ITravelRule destinationFoundRule = null);
    }
}