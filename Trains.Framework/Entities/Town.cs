using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class Town
    {
        public string Name { get; set; }

        public List<Route> Routes;
        public Town()
        {
            Routes = new List<Route>();
        }

        public void AddRoute(int weight, Town town)
        {
            this.Routes.Add(new Route
            {
                Distance = weight,
                Destination = town
            });
        }

        public override string ToString() => $"{Name} {Routes.Count()}";

        public Route GetRouteTo(string townName) => Routes.FirstOrDefault(e => e.Destination.Name == townName);
    }
}
