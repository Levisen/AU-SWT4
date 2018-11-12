using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Events
{
    public class FlightTrackDataEventArgs : EventArgs
    {
        public List<FTDataPoint> FTDataPoints { get; }
        public FlightTrackDataEventArgs(List<FTDataPoint> dp)
        {
            FTDataPoints = dp;
        }
    }
}
