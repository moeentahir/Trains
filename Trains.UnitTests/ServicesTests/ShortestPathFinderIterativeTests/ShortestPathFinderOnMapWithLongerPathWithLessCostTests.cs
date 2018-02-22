using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class ShortestPathFinderOnMapWithLongerPathWithLessCostIterativeTests
    {
        [TestMethod]
        public void Shortest_Route_From_A_To_E()
        {
            var pathFinder = new ShortestPathFinderIterative(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("E");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(8, actual);
            Assert.AreEqual("ABCDE", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(8, pathFinder.ShortestPathDetails.MyDistanceFromSource);
            Assert.AreEqual(4, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        [TestMethod]
        public void Shortest_Route_From_B_To_B()
        {
            var pathFinder = new ShortestPathFinderIterative(Map);
            var from = Map.GetTown("B");
            var to = Map.GetTown("B");

            var actual = pathFinder.FindShortestPathBetween(from, to);

            Assert.AreEqual(6, actual);
            Assert.AreEqual("BCDB", pathFinder.ShortestPathDetails.RouteCovered);
            Assert.AreEqual(6, pathFinder.ShortestPathDetails.MyDistanceFromSource);
            Assert.AreEqual(3, pathFinder.ShortestPathDetails.StopsTravelled);
        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.LongerPathWithLessCost);
        }
    }
}
