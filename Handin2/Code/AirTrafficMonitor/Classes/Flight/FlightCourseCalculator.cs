using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
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
        public float GetCurrentCourse(LinkedList<FTDataPoint> data)
        {

            double X = Math.Abs(data.First.Value.X - data.Last.Value.X);
            double Y = Math.Abs(data.First.Value.Y - data.Last.Value.Y);
            double course = Math.Atan2(X, Y) * (180 / Math.PI);
            if(data.First.Value.X > data.Last.Value.X && data.First.Value.Y <= data.Last.Value.Y) { course += 90; }
            else if(data.First.Value.X <= data.Last.Value.X && data.First.Value.Y < data.Last.Value.Y) { course += 180; }
            else if(data.First.Value.X < data.Last.Value.X && data.First.Value.Y > data.Last.Value.Y) { course += 270; }
            return (float)course;
        }
        public IFlightTrackerSingle GetFlightTracker()
        {
            return flightTracker;
        }
    }
}
