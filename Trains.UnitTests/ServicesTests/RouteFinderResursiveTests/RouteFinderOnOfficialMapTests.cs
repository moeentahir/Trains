using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Tests.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class RouteFinderOnOfficialMapTests
    {
        [TestMethod]
        public void Starting_at_C_and_ending_at_C_with_a_maximum_of_3_stops()
        {
            var pathFinder = new RouteFinderRecursive(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var paths = pathFinder.FindAllRoutesBetween(from, to, new StopsGreaterThanRule(3)).Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(2, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "CDC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBC"));
        }

        [TestMethod]
        public void Starting_at_A_and_ending_at_C_with_a_Exact_4_stops()
        {
            var pathFinder = new RouteFinderRecursive(Map);
            var from = Map.GetTown("A");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new StopsGreaterThanRule(4), new StopsEqualToRule(4));
            var paths = logs.Select(p => p.RouteCovered).ToList();

            Assert.AreEqual(3, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "ABCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADEBC"));
        }

        [TestMethod]
        public void C_TO_C_With_Distance_Less_Than_30()
        {
            var pathFinder = new RouteFinderRecursive(Map);
            var from = Map.GetTown("C");
            var to = Map.GetTown("C");

            var logs = pathFinder.FindAllRoutesBetween(from, to, new DistanceGreaterThanRule(29));
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
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Official);
        }
    }
}
