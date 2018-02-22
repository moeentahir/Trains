using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Framework;

namespace Trains.UnitTests.ServicesTests.JourneyPlannerTests
{
    [TestClass]
    public class JourneyPlannerTests
    {
        [TestMethod]
        public async Task Plan_Journey_On_Official_Map()
        {
            var map = await new World().CreateMap(MapType.Official);

            // Step 2: Plan different routs
            var plan = await new JourneyPlanner(
                map,
                new DistanceCalculator(map),
                new ShortestPathFinder(map),
                new RouteFinder(map)
                ).Plan();

            Assert.AreEqual(plan[1], "9"); //The distance of the route A-B-C.
            Assert.AreEqual(plan[2], "5"); //The distance of the route A-D.
            Assert.AreEqual(plan[3], "13"); //The distance of the route A-D-C.
            Assert.AreEqual(plan[4], "22"); //The distance of the route A-E-B-C-D.
            Assert.AreEqual(plan[5], "No such route"); //The distance of the route A-E-D.
            Assert.AreEqual(plan[6], "2"); //The number of trips starting at C and ending at C with a maximum of 3 stops.
            Assert.AreEqual(plan[7], "3"); //The number of trips starting at A and ending at C with exactly 4 stops.
            Assert.AreEqual(plan[8], "9"); //The length of the shortest route (in terms of distance to travel) from A to C.
            Assert.AreEqual(plan[9], "9"); // The length of the shortest route (in terms of distance to travel) from B to B.
            Assert.AreEqual(plan[10], "7"); //The number of different routes from C to C with a distance of less than 30
        }

        [TestMethod]
        public async Task Plan_Journey_On_Longer_Path_With_Less_Cost_Map()
        {
            var map = await new World().CreateMap(MapType.LongerPathWithLessCost);

            // Step 2: Plan different routs
            var plan = await new JourneyPlanner(
                map,
                new DistanceCalculator(map),
                new ShortestPathFinder(map),
                new RouteFinder(map)
                ).Plan();

            Assert.AreEqual(plan[1], "3"); //The distance of the route A-B-C.
            Assert.AreEqual(plan[2], "No such route"); //The distance of the route A-D.
            Assert.AreEqual(plan[3], "No such route"); //The distance of the route A-D-C.
            Assert.AreEqual(plan[4], "No such route"); //The distance of the route A-E-B-C-D.
            Assert.AreEqual(plan[5], "No such route"); //The distance of the route A-E-D.
            Assert.AreEqual(plan[6], "1"); //The number of trips starting at C and ending at C with a maximum of 3 stops.
            Assert.AreEqual(plan[7], "0"); //The number of trips starting at A and ending at C with exactly 4 stops.
            Assert.AreEqual(plan[8], "3"); //The length of the shortest route (in terms of distance to travel) from A to C.
            Assert.AreEqual(plan[9], "6"); // The length of the shortest route (in terms of distance to travel) from B to B.
            Assert.AreEqual(plan[10], "4"); //The number of different routes from C to C with a distance of less than 30
        }

        [TestMethod]
        public async Task Plan_Journey_On_Complete_Map()
        {
            var map = await new World().CreateMap(MapType.Complete);

            // Step 2: Plan different routs
            var plan = await new JourneyPlanner(
                map,
                new DistanceCalculator(map),
                new ShortestPathFinder(map),
                new RouteFinder(map)
                ).Plan();

            Assert.AreEqual(plan[1], "10"); //The distance of the route A-B-C.
            Assert.AreEqual(plan[2], "5"); //The distance of the route A-D.
            Assert.AreEqual(plan[3], "10"); //The distance of the route A-D-C.
            Assert.AreEqual(plan[4], "20"); //The distance of the route A-E-B-C-D.
            Assert.AreEqual(plan[5], "10"); //The distance of the route A-E-D.
            Assert.AreEqual(plan[6], "16"); //The number of trips starting at C and ending at C with a maximum of 3 stops.
            Assert.AreEqual(plan[7], "51"); //The number of trips starting at A and ending at C with exactly 4 stops.
            Assert.AreEqual(plan[8], "5"); //The length of the shortest route (in terms of distance to travel) from A to C.
            Assert.AreEqual(plan[9], "10"); // The length of the shortest route (in terms of distance to travel) from B to B.
            Assert.AreEqual(plan[10], "272"); //The number of different routes from C to C with a distance of less than 30
        }
    }
}
