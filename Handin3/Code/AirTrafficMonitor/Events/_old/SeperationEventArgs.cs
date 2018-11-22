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

        public bool HasSameTagsAs(IFlightTrackerSingle f1, IFlightTrackerSingle f2)
        {
            if ((FlightA.GetTag() == f1.GetTag() && FlightB.GetTag() == f2.GetTag())
                || (FlightA.GetTag() == f2.GetTag() && FlightB.GetTag() == f1.GetTag()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
