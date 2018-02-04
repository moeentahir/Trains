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
        private readonly Map Map;
        private readonly IDistanceCalculator DistanceCalculationService;
        private readonly IShortestPathFinder ShortestPathFinder;
        private readonly IRouteFinder RouteFinder;

        public JourneyPlanner(Map map, IDistanceCalculator distanceCalculationService, IShortestPathFinder shortestPathFinder, IRouteFinder routeFinder)
        {
            Map = map;
            DistanceCalculationService = distanceCalculationService;
            ShortestPathFinder = shortestPathFinder;
            RouteFinder = routeFinder;
        }

        /// <summary>
        /// Plans different journeys and returns result of each in a dictionary
        /// </summary>
        /// <returns>Dictionary where key is Operation number and value is result of the operation</returns>
        public async Task<Dictionary<int, string>> Plan()
        {
            var townA = Map.GetTown("A");
            var townB = Map.GetTown("B");
            var townC = Map.GetTown("C");

            var result = await Task.Run(() =>
            {
                return new Dictionary<int, string>
                {
                    {1, CalculationDistanceInPath("ABC") },
                    {2, CalculationDistanceInPath("AD") },
                    {3, CalculationDistanceInPath("ADC") },
                    {4, CalculationDistanceInPath("AEBCD") },
                    {5, CalculationDistanceInPath("AED") },
                    {6, RouteFinder.FindAllRoutesBetween(townC, townC, new StopsGreaterThanRule(3)).Count().ToString() },
                    {7, RouteFinder.FindAllRoutesBetween(townA, townC, new StopsGreaterThanRule(4), new StopsEqualToRule(4)).Count().ToString() },
                    {8, ShortestPathFinder.FindShortestPathBetween(townA, townC).ToString() },
                    {9, ShortestPathFinder.FindShortestPathBetween(townB, townB).ToString() },
                    {10, RouteFinder.FindAllRoutesBetween(townC, townC, new DistanceGreaterThanRule(29)).Count().ToString() }
                };
            });

            return result;
        }

        string CalculationDistanceInPath(string route)
        {
            try
            {
                return DistanceCalculationService.Calculate(route).ToString();
            }
            catch (ValidationException ex)
            {
                return ex.Message;
            }

        }
    }
}
