using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class DistanceCalculator
    {
        public DistanceCalculator(Graph graph)
        {
            Graph = graph;
        }

        public Graph Graph { get; }

        public int Calculate(string path)
        {
            if (path.Length < 2)
                throw new ValidationException("Path lenght shuould be at least two in order to calculate the distance.");

            var distance = 0;
            for (int i = 0; i < path.Length - 1; i++)
            {
                var fromNodeName = path[i].ToString();
                var toNodeName = path[i + 1].ToString();

                var fromNode = Graph.GetNode(fromNodeName);
                var edge = fromNode.GetEdgeTo(toNodeName);

                if (edge == null)
                    throw new ValidationException("No such route exists");

                distance += edge.Weight;
            }

            return distance;
        }
    }
}
