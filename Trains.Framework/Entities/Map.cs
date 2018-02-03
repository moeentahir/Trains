using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class Map
    {
        public List<Town> Towns;
        public int TotalRoutes { get; set; }
        public Map()
        {
            Towns = new List<Town>();
        }

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
                    throw new ValidationException($"Cannot find town with name {townName} in the map.");
                }
            }

            return town;
        }
    }
}
