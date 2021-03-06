﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests.BusinessRulesTests
{
    [TestClass]
    public class StopsEqualToRuleTests
    {
        [TestMethod]
        [DataRow(1, false)]
        [DataRow(4, true)]
        [DataRow(6, false)]
        public void Stops_Equal_To_4(int stops, bool expected)
        {
            var rule = new StopsEqualToRule(4);
            var actual = rule.IsMatch(new TravelCard { StopsTravelled = stops });

            Assert.AreEqual(expected, actual);
        }
    }
}
