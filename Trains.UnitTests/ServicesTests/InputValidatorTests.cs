using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests.ServicesTests
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        [ExpectExceptionWithMessage(typeof(ValidationException), "Please pass in file name that contains map information.")]
        public void No_Arguments_Should_Throw_Exception()
        {
            // Step 1: Validate and build command line arguments
            var filePath = new InputValidator(new string[] { }).Build();
        }

        [TestMethod]
        [DataRow("map.csv")]
        [DataRow("map.png")]
        [DataRow("map.doc")]
        [DataRow("map.docx")]
        [DataRow("map.csv")]
        [ExpectExceptionWithMessage(typeof(ValidationException), "Please only provide path for text files (*.txt).")]
        public void Extension_Apart_From_Text_Should_Throw_Exception(string fileName)
        {
            // Step 1: Validate and build command line arguments
            var filePath = new InputValidator(new string[] { fileName }).Build();
        }

        [TestMethod]
        [DataRow("map.txt")]
        public void Valid_File_Name_Should_Return_The_Path(string expected)
        {
            // Step 1: Validate and build command line arguments
            var actual = new InputValidator(new string[] { expected }).Build();

            Assert.AreEqual(expected, actual);
        }
    }
}
