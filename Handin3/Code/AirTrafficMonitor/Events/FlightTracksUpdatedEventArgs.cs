using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class FlightTracksUpdatedEventArgs : EventArgs
    {
        public List<IFlightTrackerSingle> UpdatedFlights { get; set; }
        public FlightTracksUpdatedEventArgs(List<IFlightTrackerSingle> flights)
        {
            UpdatedFlights = flights;
        }
    }
}
