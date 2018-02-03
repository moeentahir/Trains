using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class DistanceCalculatorTests
    {
        [TestMethod]
        [DataRow("ABC", 9)]
        [DataRow("AD", 5)]
        [DataRow("ADC", 13)]
        [DataRow("AEBCD", 22)]
        [DataRow("AE", 7)]
        [DataRow("ADCDE", 27)]
        public void Valid_Distance_For_A_Path(string path, int expected)
        {
            var distanceCalculator = new DistanceCalculator(Graph);

            var actual = distanceCalculator.Calculate(path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("AED")]
        [ExpectExceptionWithMessage(typeof(ValidationException), "No such route exists")]
        public void Invalid_Distance_Should_Thorw_exception(string path)
        {
            var distanceCalculator = new DistanceCalculator(Graph);

            var actual = distanceCalculator.Calculate(path);

        }

        public static Graph Graph { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            var graphInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            Graph = new GraphBuilder().Build(graphInput);
        }
    }
}
