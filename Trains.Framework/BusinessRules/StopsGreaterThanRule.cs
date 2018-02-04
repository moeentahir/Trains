namespace Trains.Framework
{
    public class StopsGreaterThanRule : ITravelRule
    {
        private readonly int Stops;

        public StopsGreaterThanRule(int stops)
        {
            Stops = stops;
        }
        public bool IsMatch(TravelCard ticket) => ticket.StopsTravelled > Stops;
    }
}
