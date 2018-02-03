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
                // Step 1: Validate and build command line arguments
                var filePath = new MapInputBuilder(args).Build();

                // Step 2: Plan different routs
                var planningResult = await new TrainJourneyPlanner(new MapDataReaderFromFile(filePath)).Plan();

                // Step 3: Display results
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

        private static void DisplayResult(IEnumerable<string> results)
        {
            var resultNumber = 1;
            foreach (var result in results)
            {
                Console.WriteLine($"Output #{resultNumber++}: {result}");
            }
        }
    }
}
