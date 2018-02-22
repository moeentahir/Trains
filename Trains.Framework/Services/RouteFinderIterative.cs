using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    /// <summary>
    /// This class finds all the routes in the map using depth first approach
    /// </summary>
    public class RouteFinderIterative : IRouteFinder
    {
        readonly Map Map;
        List<TravelCard> Routes;
        ITravelRule DestinationFoundRule;
        ITravelRule StopTravelingRule;
        Stack<TravelCard> Stack;
        public int RecursionCount { get; set; }

        public RouteFinderIterative(Map map)
        {
            this.Stack = new Stack<TravelCard>();
            Map = map;
        }

        /// <summary>
        /// Finds all the paths between origin and destinations. Keeps searching untill stopTravellingRule is met
        /// </summary>
        /// <returns>All possible routes between origin and destination</returns>
        public List<TravelCard> FindAllRoutesBetween(Town origin, Town destination, ITravelRule stopTravelingRule, ITravelRule destinationFoundRule = null)
        {
            Routes = new List<TravelCard>();
            RecursionCount = 0;

            StopTravelingRule = stopTravelingRule;
            DestinationFoundRule = destinationFoundRule;

            Find(origin, destination);

            return Routes;
        }


        /// <summary>
        /// Recursively goes throuhg all the paths untill it meets the StopTravellingRule passed to this class
        /// </summary>
        private void Find(Town origin, Town destination)
        {
            Stack.Push(new TravelCard
            {
                RouteCovered = $"{origin.Name}",
                StopsTravelled = 0,
                MyDistanceFromSource = 0,
                LastTownVisited = origin,
                Map = Map
            });

            while (Stack.Count > 0)
            {
                var current = Stack.Pop();

                foreach (var route in current.LastTownVisited.Routes)
                {
                    RecursionCount++;

                    var ticket = new TravelCard
                    {
                        RouteCovered = $"{current.RouteCovered}{route.Destination.Name}",
                        StopsTravelled = current.StopsTravelled + 1,
                        MyDistanceFromSource = current.MyDistanceFromSource + route.Distance,
                        LastTownVisited = route.Destination,
                        Map = Map
                    };

                    // If we get tired of travelling, stop travelling more, you might going round in circles
                    if (StopTravelingRule.IsMatch(ticket))
                        continue;

                    // Path found, add it to list and carry on traversing as there might be more ways to come back here
                    if (ticket.StopsTravelled != 0 && route.Destination.Name == destination.Name && (DestinationFoundRule?.IsMatch(ticket) ?? true))
                    {
                        Routes.Add(ticket);
                    }

                    Stack.Push(ticket);
                }
            }
        }
    }
}
