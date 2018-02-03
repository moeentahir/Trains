using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class ExatlyFourStopsRule : IPathFinderRule
    {
        public bool IsMatch(int stops) => stops == 4;
    }
}
