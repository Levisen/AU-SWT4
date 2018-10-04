﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IAirspace
    {
        List<Flight> GetAirspaceContent();
        IFlightTrackerMultiple GetFlightTracker();
    }
}
