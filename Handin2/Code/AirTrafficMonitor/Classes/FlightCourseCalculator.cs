﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    class FlightCourseCalculator : IFlightCourseCalculator
    {
        private IFlightTrackerSingle flightTracker;
        public FlightCourseCalculator(IFlightTrackerSingle ft)
        {
            flightTracker = ft;
        }
        public float GetCurrentCourse()
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
