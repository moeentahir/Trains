namespace Trains.Framework
{
    /// <summary>
    /// This rules returns true if you have travelled more than double of all the roads in the map
    /// </summary>
    public class MoreThanTwiceRoutesCoveredRule : ITravelRule
    {
        public bool IsMatch(TravelCard ticket) => ticket.StopsTravelled > (ticket.Map.TotalRoutes * 2);
    }
}
