using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests.ServicesTests
{
    [TestClass]
    public class MapRawDataReaderFromFileTests
    {
        [TestMethod]
        [ExpectExceptionWithMessage(typeof(ValidationException), "The file path 'invalid.txt' does not exist")]
        public async Task Invalid_File_Path_Should_Throw_Exception()
        {
            var file = await new MapRawDataReaderFromFile("invalid.txt").Read();
        }

        [TestMethod]
        [DataRow("LongerPathWithLessCost.txt", "AB1, BC2, CD3, DE2, AE9, DB1")]
        [DataRow("OfficialMap.txt", "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7")]
        public async Task Valid_File_Paths_Should_Read_All_Data(string filePath, string expected)
        {
            var actual = await new MapRawDataReaderFromFile(filePath).Read();

            Assert.AreEqual(expected, actual);
        }
    }
}
