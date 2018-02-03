using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class MapBuilder
    {
        public Map Build(string data)
        {
            var routes = data.Split(',').ToList();
            var map = new Map { TotalRoutes = routes.Count() };

            foreach (var route in routes)
            {
                var trimmedRoute = route.Trim();

                if (trimmedRoute.Length != 3)
                    throw new ValidationException($"Incorrect input for the map. Route {trimmedRoute} is not is correct format. Should be two letters and digit.");

                var firstTownName = trimmedRoute[0].ToString();
                var secondTownName = trimmedRoute[1].ToString();
                var weight = trimmedRoute[2].ToString().TryParseAs<int>();

                if (weight == null)
                    throw new ValidationException($"Distance for the route {trimmedRoute} should be an integer.");

                var firstTown = map.GetTown(firstTownName, createIfNotFound: true);
                var secondTown = map.GetTown(secondTownName, createIfNotFound: true);
                firstTown.AddRoute(weight.Value, secondTown);
            }
            return map;
        }
    }
}
