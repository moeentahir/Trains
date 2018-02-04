using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class ShortestPathFinderOnMapWithLongerPathWithLessCostTests
    {
        [TestMethod]
        public void Shortest_Route_From_A_To_E()
        {
            var pathFinder = new ShortestPathFinder(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("E");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(8, actual);
            Assert.AreEqual("ABCDE", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(8, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(4, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_B_To_B()
        {
            var pathFinder = new ShortestPathFinder(Map);
            var from = Map.GetTown("B");
            var to = Map.GetTown("B");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(6, actual);
            Assert.AreEqual("BCDB", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(6, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(3, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var mapInput = "AB1, BC2, CD3, DE2, AE9, DB1";
            Map = new MapBuilder().Build(mapInput);
        }
    }
}
