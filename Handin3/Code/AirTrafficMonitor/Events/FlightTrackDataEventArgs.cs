using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Events
{
    public class FlightTrackDataEventArgs : EventArgs
    {
        public List<FTDataPoint> FTDataPoints { get; set; }
        public FlightTrackDataEventArgs(List<FTDataPoint> dp)
        {
            FTDataPoints = dp;
        }
    }
}
