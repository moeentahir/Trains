using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class DistanceCalculator
    {
        public DistanceCalculator(Map map)
        {
            Map = map;
        }

        public Map Map { get; }

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
                    throw new ValidationException("No such route exists");

                distance += route.Distance;
            }

            return distance;
        }
    }
}
