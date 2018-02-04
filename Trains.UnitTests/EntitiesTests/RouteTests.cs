using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.EntitiesTests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void Verify_Display_Expression()
        {
            var route = new Route { Destination = new Town { Name = "A" }, Distance = 10 };
            var actual = route.ToString();
            var expected = "A 10";

            Assert.AreEqual(expected, actual);
        }
    }
}
