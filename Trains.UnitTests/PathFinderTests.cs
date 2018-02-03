using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Trains.UnitTests
{
    [TestClass]
    public class PathFinderTests
    {
        [TestMethod]
        public void Starting_at_C_and_ending_at_C_with_a_maximum_of_3_stops()
        {
            var pathFinder = new RouteFinder(Map, new GreaterThanThreeStopsRule());
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var paths = pathFinder.FindAllRoutesBetween(from, to).Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(2, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "CDC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBC"));
        }

        [TestMethod]
        public void Starting_at_A_and_ending_at_C_with_a_Exact_4_stops()
        {
            var pathFinder = new RouteFinder(Map, new MoreThanTwiceRoutesCoveredRule(), new ExatlyFourStopsRule());
            var from = Map.GetTown("A");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to);
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(3, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "ABCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADEBC"));
        }


        [TestMethod]
        public void C_TO_C_With_Distance_Less_Than_30()
        {
            var pathFinder = new RouteFinder(Map, new TravelDistanceGreaterThanOrEqualTo30Rule());
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to);
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(7, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "CDC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBCDC"));
            Assert.IsTrue(paths.Exists(p => p == "CDCEBC"));
            Assert.IsTrue(paths.Exists(p => p == "CDEBC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBCEBC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBCEBCEBC"));

        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var mapInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Map = new MapBuilder().Build(mapInput);
        }
    }
}
