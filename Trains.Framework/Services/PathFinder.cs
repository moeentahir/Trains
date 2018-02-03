using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class PathFinder
    {
        Graph Graph { get; }
        IPathFinderRule SuccessfullMatchRule { get; }
        List<TravelLog> Paths;

        public PathFinder(Graph graph, IPathFinderRule terminationRule)
        {
            Graph = graph;
            SuccessfullMatchRule = terminationRule;
            Paths = new List<TravelLog>();
        }

        public List<TravelLog> FindPathsBetween(Node start, Node destination)
        {
            var pathSoFar = start.Name;

            DoFind(start, destination, start.Name, 0, 0);

            return Paths;
        }

        private void DoFind(Node current, Node destination, string pathSoFar, int stopsSoFar, int distanceTravelled)
        {
            if (stopsSoFar != 0 && current.Name == destination.Name && SuccessfullMatchRule.IsMatch(stopsSoFar))// Path found, add it to list
            {
                Paths.Add(new TravelLog
                {
                    DistanceTravelled = distanceTravelled,
                    NumberOfStops = stopsSoFar,
                    PathSoFar = pathSoFar
                });
                return;
            }

            if (stopsSoFar > 20)
                return;

            foreach (var edge in current.Edges)
            {
                DoFind(edge.Node, destination, $"{pathSoFar}{edge.Node.Name}", stopsSoFar + 1, distanceTravelled + edge.Weight);
            }
        }
    }
}
