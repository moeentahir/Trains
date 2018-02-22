﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    /// <summary>
    /// Calculates the shortest path between two town using depth first approach
    /// </summary>
    public class ShortestPathFinder : IShortestPathFinder
    {
        readonly Map Map;
        Dictionary<Town, int> DistanceFromSource;

        public TravelCard ShortestPathDetails { get; set; }

        public ShortestPathFinder(Map map)
        {
            Map = map;
        }

        public int FindShortestPathBetween(Town origin, Town destination)
        {
            InitializeDistanceFromSourceList();

            var ticket = new TravelCard
            {
                RouteCovered = origin.Name,
                Map = Map
            };

            FindRecursive(origin, destination, ticket);

            return DistanceFromSource[destination];
        }

        private void InitializeDistanceFromSourceList()
        {
            DistanceFromSource = new Dictionary<Town, int>();
            foreach (var town in Map.Towns)
            {
                DistanceFromSource.Add(town, int.MaxValue);
            }
        }


        /// <summary>
        /// Recursively goes throuhg all the paths untill it meets the StopTravellingRule passed to this class
        /// </summary>
        private void FindRecursive(Town current, Town destination, TravelCard ticket)
        {
            //Update distance from source if it is less than last distance calculated
            if (ticket.StopsTravelled != 0)
                DistanceFromSource[current] = Math.Min(DistanceFromSource[current], ticket.DistanceTravelled);

            if ((ticket.StopsTravelled != 0 && current.Name == destination.Name) || // We reached the destination so no need to go further
                ticket.DistanceTravelled > DistanceFromSource[current] // We already came here with better cost so no need to go further
                )
            {
                if (current.Name == destination.Name && DistanceFromSource[current] == ticket.DistanceTravelled)
                    ShortestPathDetails = ticket;// Store ticket for debugging purposes only
                return;
            }

            // Now visit all the routes going out from this town
            foreach (var route in current.Routes)
            {
                FindRecursive(route.Destination, destination, new TravelCard
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
