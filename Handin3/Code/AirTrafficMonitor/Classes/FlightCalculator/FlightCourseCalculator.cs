using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using AirTrafficMonitor.Interfaces;
using System.Numerics;

namespace AirTrafficMonitor
{
    public class FlightCourseCalculator : IFlightCourseCalculator
    {
        public double CalculateCurrentCourse(Vector2 previous, Vector2 current)
        {
            
            if (previous == null) return 0;

            double course = 0;
            //double X = Math.Abs(previous.X - current.X);
            //double Y = Math.Abs(previous.Y - current.Y);
            //double course = Math.Atan2(X, Y) * (180 / Math.PI);

            //if(previous.X > current.X && previous.Y <= current.Y) { course += 90; }
            //else if(previous.X <= current.X && previous.Y < current.Y) { course += 180; }
            //else if(previous.X < current.X && previous.Y > current.Y) { course += 270; }


            return course;
        }
    }
}
