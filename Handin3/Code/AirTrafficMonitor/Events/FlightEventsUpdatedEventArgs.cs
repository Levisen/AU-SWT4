using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class FlightEventsUpdatedEventArgs : EventArgs
    {
        public List<IFlightEvent> CurrentEvents { get; }
        public FlightEventsUpdatedEventArgs(List<IFlightEvent> flightevents)
        {
            CurrentEvents = flightevents;
        }
    }
}
