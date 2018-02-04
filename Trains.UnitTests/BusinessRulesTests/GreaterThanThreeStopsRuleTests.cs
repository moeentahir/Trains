using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.BusinessRulesTests
{
    [TestClass]
    public class GreaterThanThreeStopsRuleTests
    {
        [TestMethod]
        [DataRow(1, false)]
        [DataRow(3, false)]
        [DataRow(4, true)]
        [DataRow(14, true)]
        [DataRow(99999999, true)]
        public void Greater_Than_Three_Stops(int stops, bool expected)
        {
            var rule = new StopsGreaterThanRule(3);
            var actual = rule.IsMatch(new TravelCard { StopsTravelled = stops });

            Assert.AreEqual(expected, actual);
        }
    }
}
