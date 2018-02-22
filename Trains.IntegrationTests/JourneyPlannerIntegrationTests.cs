using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.ServicesTests.JourneyPlannerTests
{
    [TestClass]
    public class JourneyPlannerIntegrationTests
    {
        [TestMethod]
        public async Task Plan_Journey_On_Official_Map()
        {

            // Step 1: Build map
            var mapDataReader = new MapRawDataReaderFromFile("OfficialMap.txt");
            var map = await new MapBuilder(mapDataReader).Build();

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

    }
}
