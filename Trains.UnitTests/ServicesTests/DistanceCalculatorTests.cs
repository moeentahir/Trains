using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var distanceCalculator = new DistanceCalculator(Map);

            var actual = distanceCalculator.Calculate(path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("AED")]
        [ExpectExceptionWithMessage(typeof(ValidationException), "No such route")]
        public void Invalid_Distance_Should_Thorw_exception(string path)
        {
            var distanceCalculator = new DistanceCalculator(Map);

            var actual = distanceCalculator.Calculate(path);

        }

        public static Map Map { get; set; }

        [ClassInitialize()]
        public async static Task ClassInit(TestContext context)
        {
            Map = await new World().CreateMap(MapType.Official);
        }
    }
}
