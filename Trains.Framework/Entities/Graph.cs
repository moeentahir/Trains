using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class Graph
    {
        public List<Node> Nodes;
        public Graph()
        {
            Nodes = new List<Node>();
        }

        public Node GetNode(string nodeName, bool createIfNotFound = false)
        {
            var node = Nodes.FirstOrDefault(n => n.Name == nodeName);

            if (node == null)
            {
                if (createIfNotFound)
                {
                    node = new Node { Name = nodeName };
                    Nodes.Add(node);
                }
                else
                {
                    throw new ValidationException($"Cannot find node with name {nodeName} in graph.");
                }
            }

            return node;
        }
    }
}
