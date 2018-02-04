using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.BusinessRulesTests
{
    [TestClass]
    public class MoreThanTwiceRoutesCoveredRuleTests
    {
        [TestMethod]
        [DataRow(1, 5, false)]
        [DataRow(5, 5, false)]
        [DataRow(10, 5, false)]
        [DataRow(11, 5, true)]
        [DataRow(15, 5, true)]
        [DataRow(99999, 5, true)]
        public void Verify_Rule(int stops, int routes, bool expected)
        {
            var rule = new MoreThanTwiceRoutesCoveredRule();
            var actual = rule.IsMatch(new TravelCard { StopsTravelled = stops, Map = new Map { TotalRoutes = routes } });

            Assert.AreEqual(expected, actual);
        }
    }
}
