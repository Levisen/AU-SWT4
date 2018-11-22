using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEvent : FlightEvent
    {
        public IFlightTrackerSingle Flight { get; set; }
        public bool Entered { get; set; }
        public AirspaceEvent(IFlightTrackerSingle flight, bool entered) 
            : base("Airspace", "Flight " + flight.GetTag() + " has " + ((entered) ? "entered" : "left") + " airspace at " + flight.GetNewestDataPoint().TimeStamp.ToLongTimeString())
        {
            Flight = flight;
            Entered = entered;
        }
    }
}
