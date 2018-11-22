using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class MultipleFlightTracksUpdatedEventArgs
    {
        public List<IFlightTrackerSingle> UpdatedFlights { get; set; }
        public MultipleFlightTracksUpdatedEventArgs(List<IFlightTrackerSingle> flights)
        {
            UpdatedFlights = flights;
        }
    }
}
