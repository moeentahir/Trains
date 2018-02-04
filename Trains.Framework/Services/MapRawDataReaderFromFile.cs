using System.IO;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class MapRawDataReaderFromFile: IMapRawDataReader
    {
        public MapRawDataReaderFromFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        /// <summary>
        /// Reads all contects of the file as text
        /// </summary>
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
