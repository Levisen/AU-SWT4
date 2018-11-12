using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class FlightTrackUpdatedEventArgs
    {
        public IFlightTrackerSingle UpdatedFlight { get; }
        public FlightTrackUpdatedEventArgs(IFlightTrackerSingle flight)
        {
            UpdatedFlight = flight;
        }
    }
}
