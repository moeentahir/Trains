using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    /// <summary>
    /// Validates the input and returns the file path
    /// </summary>
    public class InputValidator
    {
        const int FileArgumentIndex = 0;

        private string[] Args;

        public InputValidator(string[] args) => Args = args;

        public string Build()
        {
            Validate();

            return Args[FileArgumentIndex];
        }

        private void Validate()
        {
            if (Args == null || Args.Length != 1)
                throw new ValidationException("Please pass in file name that contains map information.");

            var filePath = Args[0];
            if (!filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                throw new ValidationException("Please only provide path for text files (*.txt).");
        }
    }
}
