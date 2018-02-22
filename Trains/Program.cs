using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;
using Trains.Framework;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            try
            {
                // Step 1: Validate command line arguments and build Path
                var filePath = new InputValidator(args).Build();

                // Step 2: Build map
                var mapDataReader = new MapRawDataReaderFromFile(filePath);
                var map = await new MapBuilder(mapDataReader).Build();

                // Step 3: Plan different routs
                var planningResult = await new JourneyPlanner(
                    map,
                    new DistanceCalculator(map),
                    new ShortestPathFinder(map),
                    new RouteFinder(map)
                    ).Plan();

                // Step 4: Display results
                DisplayResult(planningResult);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while processing your request. Error: {ex.Message}");
            }
        }

        private static void DisplayResult(Dictionary<int, string> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine($"Output #{result.Key}: {result.Value}");
            }
        }
    }
}
