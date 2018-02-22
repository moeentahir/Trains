using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.IntegrationTests
{
    [TestClass]
    public class MapBuilderIntegrationTests
    {
        [TestMethod]
        public async Task Build_Official_Map()
        {
            var fileDataReader = new MapRawDataReaderFromFile("OfficialMap.txt");
            var map = await new MapBuilder(fileDataReader).Build();

            var actual = map.Towns.Count;
            var expected = 5;
            var totalRoutes = map.Towns.SelectMany(m => m.Routes).Count();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(totalRoutes, map.TotalRoutes);
            Assert.AreEqual(9, totalRoutes);

        }

        [TestMethod]
        public async Task Build_Longer_Path_WithLess_Cost_Map()
        {
            var fileDataReader = new MapRawDataReaderFromFile("LongerPathWithLessCost.txt");
            var map = await new MapBuilder(fileDataReader).Build();
            var totalRoutes = map.Towns.SelectMany(m => m.Routes).Count();

            Assert.AreEqual(5, map.Towns.Count);
            Assert.AreEqual(totalRoutes, map.TotalRoutes);
            Assert.AreEqual(6, totalRoutes);

        }

        [TestMethod]
        public async Task Build_Complete_Map()
        {
            var fileDataReader = new MapRawDataReaderFromFile("CompleteMap.txt");
            var map = await new MapBuilder(fileDataReader).Build();
            var totalRoutes = map.Towns.SelectMany(m => m.Routes).Count();

            Assert.AreEqual(5, map.Towns.Count);
            Assert.AreEqual(totalRoutes, map.TotalRoutes);
            Assert.AreEqual(20, totalRoutes);

        }
    }
}
