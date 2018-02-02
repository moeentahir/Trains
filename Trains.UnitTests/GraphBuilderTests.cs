using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;

namespace Trains.UnitTests
{
    [TestClass]
    public class GraphBuilderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var graphInput = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
            var graphBuilder = new GraphBuilder().Build(graphInput);
        }
    }
}
