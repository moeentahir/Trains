namespace Trains.Framework
{
    public class DistanceGreaterThanRule : ITravelRule
    {
        private readonly int Distance;

        public DistanceGreaterThanRule(int distance)
        {
            this.Distance = distance;
        }
        public bool IsMatch(TravelCard ticket) => ticket.DistanceTravelled > Distance;
    }
}
