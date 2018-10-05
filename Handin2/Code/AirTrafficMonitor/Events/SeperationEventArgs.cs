using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class SeperationEventArgs : EventArgs
    {
        public IFlightTrackerSingle FlightA;
        public IFlightTrackerSingle FlightB;
        public DateTime TimeOfOccurance;

        public SeperationEventArgs(IFlightTrackerSingle a, IFlightTrackerSingle b, DateTime timeOfOccurance)
        {
            FlightA = a;
            FlightB = b;
            TimeOfOccurance = timeOfOccurance;
        }
    }
}
