using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class Node
    {
        public string Name { get; set; }

        List<Edge> Edges;
        public Node()
        {
            Edges = new List<Edge>();
        }

        void AddEdge(int weight, Node node)
        {
            this.Edges.Add(new Edge
            {
                Weight = weight,
                Node = node
            });
        }
    }
}
