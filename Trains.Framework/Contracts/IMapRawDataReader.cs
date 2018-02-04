using System.Threading.Tasks;

namespace Trains.Framework
{
    public interface IMapRawDataReader
    {
        Task<string> Read();
    }
}
