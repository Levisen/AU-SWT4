using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    class FlightVelocityCalculator : IFlightVelocityCalculator
    {
        private IFlightTrackerSingle flightTracker;
        public FlightVelocityCalculator(IFlightTrackerSingle ft)
        {
            flightTracker = ft;
        }
        public float GetCurrentVelocity()
        {
            //throw new NotImplementedException();
            return 0;
        }

        public void AddDataPoint(FTDataPoint dp)
        {
            flightTracker.AddDataPoint(dp);
        }

        public ICollection<FTDataPoint> GetFullDataLog()
        {
            return flightTracker.GetFullDataLog();
        }

        public FTDataPoint GetNewestDataPoint()
        {
            return flightTracker.GetNewestDataPoint();
        }
    }
}
