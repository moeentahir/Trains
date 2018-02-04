using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Common;
using Trains.Common;
using Trains.Framework;

namespace Trains.UnitTests.EntitiesTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void Town_That_Does_Not_Exists_Get_Created()
        {
            var map = new Map();
            var townName = "A";
            var town = map.GetTown(townName, createIfNotFound: true);

            Assert.AreEqual(townName, town.Name);
            Assert.AreEqual(1, map.Towns.Count);
        }

        [TestMethod]
        public void Town_That_Exists_Is_Returned()
        {
            var map = new Map();
            var townName = "A";
            map.GetTown(townName, createIfNotFound: true);//Create town

            var town = map.GetTown(townName);// retrieve town

            Assert.AreEqual(townName, town.Name);
            Assert.AreEqual(1, map.Towns.Count);
        }

        [TestMethod]
        [ExpectExceptionWithMessage(typeof(ValidationException), "Cannot find town with name 'A' in the map.")]
        public void Getting_Town_That_Does_Not_Exists_Throws_Exception()
        {
            var map = new Map();
            var townName = "A";
            var town = map.GetTown(townName);

        }

    }
}
