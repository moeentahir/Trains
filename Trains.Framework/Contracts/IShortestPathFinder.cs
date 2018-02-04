namespace Trains.Framework
{
    public interface IShortestPathFinder
    {
        TravelCard ShortestPathDetails { get; set; }

        int FindShortestPathBetween(Town origin, Town destination);
    }
}