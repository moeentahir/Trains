using System.Linq;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class MapBuilder : IMapBuilder
    {
        public MapBuilder(IMapRawDataReader reader)
        {
            Reader = reader;
        }

        public IMapRawDataReader Reader { get; }

        public async Task<Map> Build()
        {
            var data = await Reader.Read();
            data = data.ToUpper();
            var routes = data.Split(',').ToList();
            var map = new Map();
            var routesCount = 0;

            foreach (var route in routes)
            {
                var trimmedRoute = route.Trim();
                if (trimmedRoute.IsEmpty())
                    continue;

                if (trimmedRoute.Length != 3)
                    throw new ValidationException($"Incorrect input for the map. Route '{trimmedRoute}' is not is correct format. Should be two letters and digit.");

                var firstTownName = trimmedRoute[0].ToString();
                var secondTownName = trimmedRoute[1].ToString();
                var distance = trimmedRoute[2].ToString().TryParseAs<int>();

                if (distance == null)
                    throw new ValidationException($"Distance for the route {trimmedRoute} should be an integer.");

                var firstTown = map.GetTown(firstTownName, createIfNotFound: true);
                var secondTown = map.GetTown(secondTownName, createIfNotFound: true);
                firstTown.AddRoute(secondTown, distance.Value);
                routesCount++;
            }
            map.TotalRoutes = routesCount;
            return map;
        }
    }
}
