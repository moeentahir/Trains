using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class MapDataReaderFromFile: IMapDataReader
    {
        public MapDataReaderFromFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public async Task<string> Read()
        {
            var result = string.Empty;

            if (!File.Exists(FilePath))
                throw new ValidationException($"The file path '{FilePath}' does not exist");

            using (var reader = File.OpenText(FilePath))
            {
                result = await reader.ReadToEndAsync();
            }

            return result;
        }
    }
}
