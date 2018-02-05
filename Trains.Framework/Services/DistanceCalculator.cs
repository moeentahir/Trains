using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    /// <summary>
    /// Calculates the disctance along a specific path
    /// </summary>
    public class DistanceCalculator : IDistanceCalculator
    {
        readonly Map Map;

        public DistanceCalculator(Map map)
        {
            Map = map;
        }

        /// <summary>
        /// Goes through the speciefied path, if no route exists between two towns, it will throw exception 
        /// </summary>
        /// <returns>Total distance across the whole path</returns>
        public int Calculate(string path)
        {
            if (path.Length < 2)
                throw new ValidationException("Path lenght shuould be at least two in order to calculate the distance.");

            var distance = 0;
            for (int i = 0; i < path.Length - 1; i++)
            {
                var fromTownName = path[i].ToString();
                var toTownName = path[i + 1].ToString();

                var fromTown = Map.GetTown(fromTownName);
                var route = fromTown.GetRouteTo(toTownName);

                if (route == null)
                    throw new ValidationException("No such route");

                distance += route.Distance;
            }

            return distance;
        }
    }
}
