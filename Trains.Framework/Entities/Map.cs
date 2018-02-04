using System.Collections.Generic;
using System.Linq;
using Trains.Common;

namespace Trains.Framework
{
    /// <summary>
    /// Contains list of all towns in the map and those towns then contain link between them
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Contains list of all the towns in the map
        /// </summary>
        public List<Town> Towns { get; }

        /// <summary>
        /// Nmber of all the direct routes between two towns without stopping any other town
        /// </summary>
        public int TotalRoutes { get; set; }

        public Map()
        {
            Towns = new List<Town>();
        }

        /// <summary>
        /// Returns town object in the map
        /// </summary>
        /// <param name="townName">Name of the town</param>
        /// <param name="createIfNotFound">If town not found in the map, setting it true will create it and then return. Setting it to false when town not found will throw exception.</param>
        /// <returns></returns>
        public Town GetTown(string townName, bool createIfNotFound = false)
        {
            var town = Towns.FirstOrDefault(n => n.Name == townName);

            if (town == null)
            {
                if (createIfNotFound)
                {
                    town = new Town { Name = townName };
                    Towns.Add(town);
                }
                else
                {
                    throw new ValidationException($"Cannot find town with name '{townName}' in the map.");
                }
            }

            return town;
        }
    }
}
