using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class RouteFinder
    {
        Map Map { get; }
        ITravelRule DestinationFoundRule { get; }
        ITravelRule StopTravelingRule { get; }
        List<TravelLog> Routes;

        public RouteFinder(Map map, ITravelRule stopTravelingRule, ITravelRule destinationFoundRule = null)
        {
            StopTravelingRule = stopTravelingRule;
            Map = map;
            DestinationFoundRule = destinationFoundRule;
            Routes = new List<TravelLog>();
        }

        public List<TravelLog> FindAllRoutesBetween(Town origin, Town destination)
        {
            var ticket = new TravelLog
            {
                RouteCovered = origin.Name,
                Map = Map
            };

            FindRecursive(origin, destination, ticket);

            return Routes;
        }

        private void FindRecursive(Town current, Town destination, TravelLog ticket)
        {
            // If we get tired of travelling, stop travelling more, you might going round in circles
            if (StopTravelingRule.IsMatch(ticket))
                return;

            // Path found, add it to list and carry on traversing as there might be more ways to come back here
            if (ticket.StopsTravelled != 0 && current.Name == destination.Name && (DestinationFoundRule?.IsMatch(ticket) ?? true))
            {
                Routes.Add(ticket);
            }

            // Now visit all the routes going out from this town
            foreach (var route in current.Routes)
            {
                FindRecursive(route.Destination, destination, new TravelLog
                {
                    RouteCovered = $"{ticket.RouteCovered}{route.Destination.Name}",
                    StopsTravelled = ticket.StopsTravelled + 1,
                    DistanceTravelled = ticket.DistanceTravelled + route.Distance,
                    Map = Map
                });
            }
        }
    }
}
