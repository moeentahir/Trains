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

        /// <summary>
        /// This class finds all the routes in the map using depth first approach
        /// </summary>
        /// <param name="map">An initialized map object with Towns and Routes configured</param>
        /// <param name="stopTravelingRule">Specify a rule here when to stop searching for the path. If there are loops in the Map then this makes sure you don't travel in cycles</param>
        /// <param name="destinationFoundRule">If you want to add some extra condition in finding the destination specify them here. Passing null will ignore this.</param>
        public RouteFinder(Map map, ITravelRule stopTravelingRule, ITravelRule destinationFoundRule = null)
        {
            StopTravelingRule = stopTravelingRule;
            Map = map;
            DestinationFoundRule = destinationFoundRule;
            Routes = new List<TravelLog>();
        }

        /// <summary>
        /// Finds all the paths between origin and destinations
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Recursively goes throuhg all the paths untill it meets the StopTravellingRule passed to this class
        /// </summary>
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
