using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class MapBuilderTests
    {
        [TestMethod]
        public void Build_Official_Map()
        {
            var mapInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            var map = new MapBuilder().Build(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Empty_Map_Should_Build_Map_With_No_Wowns()
        {
            var map = new MapBuilder().Build(string.Empty);

            Assert.AreEqual(0, map.Towns.Count);
            Assert.AreEqual(0, map.TotalRoutes);

        }

        [TestMethod]
        public void Lower_And_Mixed_Case_Should_Still_Work()
        {
            var mapInput = "ab5,Bc4, Cd8,DC8, DE6, AD5, CE2, EB3, AE7";
            var map = new MapBuilder().Build(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(9, map.TotalRoutes);

        }


        [TestMethod]
        public void Unnecessary_Commas_Should_Be_Ignored()
        {
            var mapInput = "ab5,Bc4, Cd8,DC8, DE6, AD5,,, CE2, EB3, AE7,";
            var map = new MapBuilder().Build(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(9, map.TotalRoutes);

        }
    }
}
