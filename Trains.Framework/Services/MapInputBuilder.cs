using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Common;

namespace Trains.Framework
{
    public class MapInputBuilder
    {
        const int FileArgumentIndex = 0;

        private string[] Args;

        public MapInputBuilder(string[] args) => Args = args;

        public string Build()
        {
            Validate();

            return Args[FileArgumentIndex];
        }

        private void Validate()
        {
            if (Args == null || Args.Length != 1)
                throw new ValidationException("Please pass in file name that contains map information.");
        }
    }
}
