using System.Threading.Tasks;

namespace Trains.Framework
{
    public interface IMapBuilder
    {
        Task<Map> Build();
    }
}