using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class GraphBuilder
    {
        public Graph Build(string data)
        {
            var result = new Graph();

            var edges = data.Split(',');

            foreach (var edge in edges)
            {
                var formattedEdge = edge.Trim();

                if (formattedEdge.Length != 3)
                    throw new ValidationException("Incorrect input for the graph. Edge {formattedEdge} is not is correct format. Should be two letters and digit.");

                var firstNodeName = formattedEdge[0];
                var secondNodeName = formattedEdge[1];
                var weight = formattedEdge[2].ToString().TryParseAs<int>();

                if (weight == null)
                    throw new ValidationException("Weight for the edge {formattedEdge} should be an integer.");
            }


            return result;
        }
    }
}
