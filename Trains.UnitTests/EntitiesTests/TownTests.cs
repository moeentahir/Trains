using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.EntitiesTests
{
    [TestClass]
    public class TownTests
    {
        [TestMethod]
        public void Verify_Display()
        {
            var town = new Town { Name = "A" };
            var expected = "A";
            var actual =town.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Adding_Route_Between_Two_Towns_Should_Add_Route()
        {
            var townA = new Town { Name = "A" };
            var townB = new Town { Name = "B" };

            townA.AddRoute(townB, 10);

            Assert.AreEqual(1, townA.Routes.Count);
        }

        [TestMethod]
        public void Retrievieng_Route_That_Already_Exists_Should_Return_The_Route()
        {
            var townA = new Town { Name = "A" };
            var townB = new Town { Name = "B" };
            townA.AddRoute(townB, 10);

            var route = townA.GetRouteTo("B");

            Assert.AreEqual("B", route.Destination.Name);
            Assert.AreEqual(10, route.Distance);
        }

        [TestMethod]
        public void Retrievieng_Route_That_Does_Not_Exists_Should_Return_Null()
        {
            var townA = new Town { Name = "A" };
            var townB = new Town { Name = "B" };
            townA.AddRoute(townB, 10);

            var route = townA.GetRouteTo("C");

            Assert.IsNull(route);

        }

    }
}
