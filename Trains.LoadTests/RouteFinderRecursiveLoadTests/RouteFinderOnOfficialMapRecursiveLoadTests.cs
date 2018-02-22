using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Common;
using System.Diagnostics;

namespace Trains.UnitTests
{
    [TestClass]
    public class RouteFinderOnOfficialMapRecursiveLoadTests
    {

        [TestMethod]
        public void C_TO_C_With_Large_Stops()
        {
            var pathFinder = new RouteFinderRecursive(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new StopsGreaterThanRule(40));
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.IsTrue(paths.All(p => p.StartsWith("C")));
            Assert.IsTrue(paths.All(p => p.EndsWith("C")));

            Debug.WriteLine($"Total paths: {paths.Count().ToString("N0")}");
            Debug.WriteLine($"Total recursions: {pathFinder.RecursionCount.ToString("N0")}");

        }

        [TestMethod]
        public void C_TO_C_With_Max_Distance()
        {
            var pathFinder = new RouteFinderRecursive(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new DistanceGreaterThanRule(200));
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.IsTrue(paths.All(p => p.StartsWith("C")));
            Assert.IsTrue(paths.All(p => p.EndsWith("C")));

            Debug.WriteLine($"Total paths: {paths.Count().ToString("N0")}");
            Debug.WriteLine($"Total recursions: {pathFinder.RecursionCount.ToString("N0")}");

        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Official);
        }
    }
}
