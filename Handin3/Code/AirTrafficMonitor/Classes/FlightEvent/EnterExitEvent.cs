using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class EnterExitEvent : FlightEvent
    {
        public IFlightTrack Flight { get; set; }
        public bool Entered { get; set; }
        public EnterExitEvent(IFlightTrack flight, bool entered) 
            : base("Airspace", "Flight " + flight.GetTag() + " has " + ((entered) ? "entered" : "left") + " airspace at " + flight.GetLastUpdatedAt().ToLongTimeString())
        {
            Flight = flight;
            Entered = entered;
        }
    }
}
