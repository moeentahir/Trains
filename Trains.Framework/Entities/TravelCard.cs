namespace Trains.Framework
{
    /// <summary>
    /// Represents all the travle information from soure till destination
    /// </summary>
    public class TravelCard
    {
        /// <summary>
        /// Rout that you have covered, will be concatenated string of stop names
        /// </summary>
        public string RouteCovered { get; set; }

        /// <summary>
        /// Number of stops visited in a route
        /// </summary>
        public int StopsTravelled { get; set; }

        /// <summary>
        /// Distance covered across the whole route
        /// </summary>
        public int DistanceTravelled { get; set; }

        public Map Map { get; set; }

        public override string ToString() => $"Path: {RouteCovered} | Distance: {DistanceTravelled} | Stops: {StopsTravelled}";

    }
}
