﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Framework
{
    public interface ITravelRule
    {
        bool IsMatch(TravelLog ticket);
    }
}
