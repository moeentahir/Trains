using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    /// <summary>
    /// Represents one diretional link between two towns
    /// </summary>
    public class Route
    {
        /// <summary>
        /// The town that this route takes you to
        /// </summary>
        public Town Destination { get; set; }

        /// <summary>
        /// Distance between the parent town tht contains this route and the destination
        /// </summary>
        public int Distance { get; set; }

        public override string ToString() => $"{Destination} {Distance}";
    }
}
