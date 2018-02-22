using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class ShortestPathFinderOnCompleteMapTests
    {
        [TestMethod]
        public void Shortest_Route_From_A_To_C()
        {
            var pathFinder = new ShortestPathFinder(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("C");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(5, actual);
            Assert.AreEqual("AC", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(5, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(1, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_B_To_B()
        {
            var pathFinder = new ShortestPathFinder(Map);
            var from = Map.GetTown("B");
            var to = Map.GetTown("B");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(10, actual);
            Assert.AreEqual("BEB", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(10, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(2, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_A_To_E()
        {
            var pathFinder = new ShortestPathFinder(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("E");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(5, actual);
            Assert.AreEqual("AE", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(5, pathFinder.ShortestPathDetails.DistanceTravelled);
            Assert.AreEqual(1, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Complete);
        }
    }
}
