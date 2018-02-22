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
                MyDistanceFromSource = 10,
                RouteCovered = "ABC",
                StopsTravelled = 2

            };
            var actual = log.ToString();
            var expected = "Path: ABC | My Distance: 10 | Others Distance: 0 | Stops: 2";

            Assert.AreEqual(expected, actual);
        }
    }
}
