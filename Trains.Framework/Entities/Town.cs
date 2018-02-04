using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class Town
    {
        /// <summary>
        /// Name of the town
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All the routes that take you to the neighbouring towns
        /// </summary>
        public List<Route> Routes { get; }

        public Town()
        {
            Routes = new List<Route>();
        }

        /// <summary>
        /// Adds a route to the neighbouring town
        /// </summary>
        public void AddRoute(Town neighbouringTown, int distance)
        {
            Routes.Add(new Route
            {
                Distance = distance,
                Destination = neighbouringTown
            });
        }

        /// <summary>
        /// Gets rout to the neighbouring town, returns null if no route exists
        /// </summary>
        /// <param name="townName">Neighbouring town name</param>
        /// <returns></returns>
        public Route GetRouteTo(string townName) => Routes.FirstOrDefault(e => e.Destination.Name == townName);

        public override string ToString() => $"{Name}";
    }
}
