using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Framework;

namespace Tests.Common
{
    public class World
    {
        Dictionary<MapType, string> Maps;

        public World()
        {
            Maps = new Dictionary<MapType, string>
            {
                { MapType.Official, "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7" },
                { MapType.LongerPathWithLessCost, "AB1, BC2, CD3, DE2, AE9, DB1" },
                { MapType.Complete, @"AB5,AC5,AD5,AE5,
BA5,BC5,BD5,BE5,
CA5,CB5,CD5,CE5,
DA5,DB5,DC5,DE5,
EA5,EB5,EC5,ED5," }
            };
        }

        public async Task<Map> CreateMap(MapType type) => await CreateMap(Maps[type]);

        public async Task<Map> CreateMap(string input)
        {
            var mapInput = Task.FromResult(input);
            var mapReaderMock = new Mock<IMapRawDataReader>();
            mapReaderMock.Setup(m => m.Read()).Returns(mapInput);

            return await new MapBuilder(mapReaderMock.Object).Build();
        }
    }
}
