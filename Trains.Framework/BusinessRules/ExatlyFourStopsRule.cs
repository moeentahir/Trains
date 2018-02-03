using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public class ExatlyFourStopsRule : ITravelRule
    {
        public bool IsMatch(TravelLog ticket) => ticket.StopsTravelled == 4;
    }
}
