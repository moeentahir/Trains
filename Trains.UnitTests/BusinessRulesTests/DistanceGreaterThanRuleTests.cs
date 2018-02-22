using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.BusinessRulesTests
{
    [TestClass]
    public class DistanceGreaterThanRuleTests
    {
        [TestMethod]
        [DataRow(1, false)]
        [DataRow(3, false)]
        [DataRow(15, false)]
        [DataRow(29, false)]
        [DataRow(30, true)]
        [DataRow(31, true)]
        [DataRow(9999, true)]
        public void Distance_Greater_Than_Or_Equal_To_30(int stops, bool expected)
        {
            var rule = new DistanceGreaterThanRule(29);
            var actual = rule.IsMatch(new TravelCard { MyDistanceFromSource = stops });

            Assert.AreEqual(expected, actual);
        }
    }
}
