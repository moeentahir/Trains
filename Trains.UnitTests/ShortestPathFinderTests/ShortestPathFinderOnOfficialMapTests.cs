using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class ShortestPathFinderOnOfficialMapTests
    {
        [TestMethod]
        public void Shortest_Route_From_A_To_C()
        {
            var pathFinder = new ShortestPathFinder(OfficialMap);
            var from = OfficialMap.GetTown("A");
            var to = OfficialMap.GetTown("C");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(9, actual);
            Assert.AreEqual("ABC", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(9, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(2, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_B_To_B()
        {
            var pathFinder = new ShortestPathFinder(OfficialMap);
            var from = OfficialMap.GetTown("B");
            var to = OfficialMap.GetTown("B");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(9, actual);
            Assert.AreEqual("BCEB", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(9, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(3, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_A_To_E()
        {
            var pathFinder = new ShortestPathFinder(OfficialMap);
            var from = OfficialMap.GetTown("A");
            var to = OfficialMap.GetTown("E");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(7, actual);
            Assert.AreEqual("AE", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(7, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(1, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        public static Map OfficialMap { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var mapInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            OfficialMap = new MapBuilder().Build(mapInput);
        }
    }
}
