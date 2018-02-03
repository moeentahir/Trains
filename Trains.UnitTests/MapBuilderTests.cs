using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class MapBuilderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mapInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            var map = new MapBuilder().Build(mapInput);

            var actual = map.Towns.Count;
            var expected = 5;

            Assert.AreEqual(expected, actual);

        }
    }
}
