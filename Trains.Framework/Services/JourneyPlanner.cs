using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class JourneyPlanner
    {
        private Map Map;

        public JourneyPlanner(IMapDataReader mapDataReader)
        {
            MapDataReader = mapDataReader;
        }

        public IMapDataReader MapDataReader { get; }

        public async Task<IEnumerable<string>> Plan()
        {
            await CreateMap();

            var townA = Map.GetTown("A");
            var townB = Map.GetTown("B");
            var townC = Map.GetTown("C");


            var result = new List<string>
            {
                CalculationDistanceInPath("ABC"),
                CalculationDistanceInPath("AD"),
                CalculationDistanceInPath("ADC"),
                CalculationDistanceInPath("AEBCD"),
                CalculationDistanceInPath("AED"),
                new RouteFinder(Map, new GreaterThanThreeStopsRule()).FindAllRoutesBetween(townC, townC).Count().ToString(),
                new RouteFinder(Map, new MoreThanTwiceRoutesCoveredRule(), new ExatlyFourStopsRule()).FindAllRoutesBetween(townA, townC).Count().ToString(),
                new ShortestPathFinder(Map).FindShortestPathBetween(townA, townC).ToString(),
                new ShortestPathFinder(Map).FindShortestPathBetween(townB, townB).ToString(),
                new RouteFinder(Map, new TravelDistanceGreaterThanOrEqualTo30Rule()).FindAllRoutesBetween(townC, townC).Count().ToString()
            };

            return result;
        }

        private async Task CreateMap()
        {
            var mapInput = await MapDataReader.Read();

            Map = new MapBuilder().Build(mapInput);
        }

        string CalculationDistanceInPath(string route)
        {
            try
            {
                return new DistanceCalculator(Map).Calculate(route).ToString();
            }
            catch (ValidationException ex)
            {
                return ex.Message;
            }

        }
    }
}
