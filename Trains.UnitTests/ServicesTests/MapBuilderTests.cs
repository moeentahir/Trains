using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class MapBuilderTests
    {
        [TestMethod]
        public async Task Build_Official_Map()
        {
            var mapInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            var map = await BuildMap(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public async Task Empty_Map_Should_Build_Map_With_No_Wowns()
        {
            var map = await BuildMap(string.Empty);

            Assert.AreEqual(0, map.Towns.Count);
            Assert.AreEqual(0, map.TotalRoutes);

        }

        [TestMethod]
        public async Task Lower_And_Mixed_Case_Should_Still_Work()
        {
            var mapInput = "ab5,Bc4, Cd8,DC8, DE6, AD5, CE2, EB3, AE7";
            var map = await BuildMap(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(9, map.TotalRoutes);

        }


        [TestMethod]
        public async Task Unnecessary_Commas_Should_Be_Ignored()
        {
            var mapInput = "ab5,Bc4, Cd8,DC8, DE6, AD5,,, CE2, EB3, AE7,";
            var map = await BuildMap(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(9, map.TotalRoutes);

        }

        async Task<Map> BuildMap(string input)
        {
            var mapReaderMock = new Mock<IMapRawDataReader>();
            mapReaderMock.Setup(m => m.Read()).Returns(Task.FromResult(input));

            return await new MapBuilder(mapReaderMock.Object).Build();
        }
    }
}
