using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.EntitiesTests
{
    [TestClass]
    public class TravelCardTests
    {
        [TestMethod]
        public void Verify_Display()
        {
            var log = new TravelCard
            {
                DistanceTravelled = 10,
                RouteCovered = "ABC",
                StopsTravelled = 2

            };
            var actual = log.ToString();
            var expected = "Path: ABC | Distance: 10 | Stops: 2";

            Assert.AreEqual(expected, actual);
        }
    }
}
