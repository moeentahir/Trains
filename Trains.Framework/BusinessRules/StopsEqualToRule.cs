namespace Trains.Framework
{
    public class StopsEqualToRule : ITravelRule
    {
        private readonly int Stops;

        public StopsEqualToRule(int stops)
        {
            Stops = stops;
        }
        public bool IsMatch(TravelCard ticket) => ticket.StopsTravelled == Stops;
    }
}
