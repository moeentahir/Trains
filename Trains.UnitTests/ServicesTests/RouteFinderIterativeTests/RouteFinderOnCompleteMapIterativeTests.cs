using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Tests.Common;

namespace Trains.UnitTests
{
    [TestClass]
    public class RouteFinderOnCompleteMapIterativeTests
    {
        [TestMethod]
        public void Starting_at_C_and_ending_at_C_with_a_maximum_of_3_stops()
        {
            var pathFinder = new RouteFinderIterative(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var paths = pathFinder.FindAllRoutesBetween(from, to, new StopsGreaterThanRule(3)).Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(16, paths.Count);
            Assert.IsTrue(paths.All(p => p.StartsWith("C")));
            Assert.IsTrue(paths.All(p => p.EndsWith("C")));
        }

        [TestMethod]
        public void Starting_at_A_and_ending_at_C_with_a_Exact_4_stops()
        {
            var pathFinder = new RouteFinderIterative(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new StopsGreaterThanRule(4), new StopsEqualToRule(4));
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(51, paths.Count);
            Assert.IsTrue(paths.All(p => p.StartsWith("A")));
            Assert.IsTrue(paths.All(p => p.EndsWith("C")));
            Assert.IsTrue(paths.All(p => p.Length == 5));
            Assert.IsTrue(logs.All(l => l.StopsTravelled == 4));
        }

        [TestMethod]
        public void C_TO_C_With_Distance_Less_Than_30()
        {
            var pathFinder = new RouteFinderIterative(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new DistanceGreaterThanRule(29));
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(272, paths.Count);
            Assert.IsTrue(paths.All(p => p.StartsWith("C")));
            Assert.IsTrue(paths.All(p => p.EndsWith("C")));

        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Complete);
        }
    }
}
