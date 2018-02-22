using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class ShortestPathFinderOnOfficialMapTests
    {
        [TestMethod]
        public void Shortest_Route_From_A_To_C()
        {
            var pathFinder = new ShortestPathFinderRecursive(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("C");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(9, actual);
            Assert.AreEqual("ABC", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(9, pathFinder.ShortestPathDetails.MyDistanceFromSource);
            Assert.AreEqual(2, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_B_To_B()
        {
            var pathFinder = new ShortestPathFinderRecursive(Map);
            var from = Map.GetTown("B");
            var to = Map.GetTown("B");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(9, actual);
            Assert.AreEqual("BCEB", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(9, pathFinder.ShortestPathDetails.MyDistanceFromSource);
            Assert.AreEqual(3, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_A_To_E()
        {
            var pathFinder = new ShortestPathFinderRecursive(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("E");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(7, actual);
            Assert.AreEqual("AE", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(7, pathFinder.ShortestPathDetails.MyDistanceFromSource);
            Assert.AreEqual(1, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Official);
        }
    }
}
