namespace Trains.Framework
{
    public interface ITravelRule
    {
        bool IsMatch(TravelCard ticket);
    }
}
