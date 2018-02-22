using System;
using System.Collections;
using System.Collections.Generic;
using Trains.Framework;

namespace Trains.Framework
{
    public class ShortestPathFinderIterative : IShortestPathFinder
    {
        private Map Map;

        Dictionary<Town, TravelCard> DistanceFromSource;

        public TravelCard ShortestPathDetails { get; set; }

        Queue<Town> Queue;

        public ShortestPathFinderIterative(Map map)
        {
            this.Map = map;
            this.Queue = new Queue<Town>();
        }

        public int FindShortestPathBetween(Town origin, Town destination)
        {
            InitializeDistanceFromSourceList();

            var ticket = new TravelCard
            {
                RouteCovered = origin.Name,
                Map = Map
            };

            FindIterative(origin, destination);


            ShortestPathDetails = DistanceFromSource[destination];

            return DistanceFromSource[destination].MyDistanceFromSource;
        }

        private void FindIterative(Town origin, Town destination)
        {
            Queue.Enqueue(origin);
            DistanceFromSource[origin].OthersDistanceFromSource = 0;
            DistanceFromSource[origin].RouteCovered = origin.Name;

            while (Queue.Count != 0)
            {
                var current = Queue.Dequeue();

                foreach (var route in current.Routes)
                {
                    var distanceSoFar = DistanceFromSource[current].OthersDistanceFromSource + route.Distance;
                    if (distanceSoFar < DistanceFromSource[route.Destination].MyDistanceFromSource)
                    {
                        DistanceFromSource[route.Destination].MyDistanceFromSource = distanceSoFar;
                        DistanceFromSource[route.Destination].OthersDistanceFromSource = distanceSoFar;
                        DistanceFromSource[route.Destination].RouteCovered = $"{DistanceFromSource[current].RouteCovered}{route.Destination.Name}";
                        DistanceFromSource[route.Destination].StopsTravelled = DistanceFromSource[current].StopsTravelled + 1;
                        Queue.Enqueue(route.Destination);
                    }
                }
            }
        }

        private void InitializeDistanceFromSourceList()
        {
            DistanceFromSource = new Dictionary<Town, TravelCard>();
            foreach (var town in Map.Towns)
            {
                DistanceFromSource.Add(town, new TravelCard { MyDistanceFromSource = int.MaxValue });
            }
        }
    }
}