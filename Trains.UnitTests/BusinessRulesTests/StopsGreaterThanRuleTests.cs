using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.BusinessRulesTests
{
    [TestClass]
    public class StopsGreaterThanRuleTests
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

        [TestMethod]
        [DataRow(1, false)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(14, true)]
        [DataRow(99999999, true)]
        public void Greater_Than_Four_Stops(int stops, bool expected)
        {
            var rule = new StopsGreaterThanRule(4);
            var actual = rule.IsMatch(new TravelCard { StopsTravelled = stops });

            Assert.AreEqual(expected, actual);
        }
    }
}
