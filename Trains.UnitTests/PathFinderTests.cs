using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Trains.UnitTests
{
    [TestClass]
    public class PathFinderTests
    {
        [TestMethod]
        public void Starting_at_C_and_ending_at_C_with_a_maximum_of_3_stops()
        {
            var pathFinder = new PathFinder(Graph, new MaximumThreeStopsRule());
            var from = Graph.GetNode("C");
            var to = Graph.GetNode("C");

            var paths = pathFinder.FindPathsBetween(from, to).Select(p => p.PathSoFar).ToList();

            Assert.AreEqual(2, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "CDC"));
            Assert.IsTrue(paths.Exists(p => p == "CEBC"));
        }

        [TestMethod]
        public void Starting_at_A_and_ending_at_C_with_a_Exact_4_stops()
        {
            var pathFinder = new PathFinder(Graph, new ExatlyFourStopsRule());
            var from = Graph.GetNode("A");
            var to = Graph.GetNode("C");

            var logs = pathFinder.FindPathsBetween(from, to);
            var paths = logs.Select(p => p.PathSoFar).ToList();

            Assert.AreEqual(3, paths.Count);
            Assert.IsTrue(paths.Exists(p => p == "ABCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADCDC"));
            Assert.IsTrue(paths.Exists(p => p == "ADEBC"));
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
