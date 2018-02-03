using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class Edge
    {
        public int Weight { get; set; }

        public Node Node { get; set; }

        public override string ToString() => $"{Node} {Weight}";
    }
}
