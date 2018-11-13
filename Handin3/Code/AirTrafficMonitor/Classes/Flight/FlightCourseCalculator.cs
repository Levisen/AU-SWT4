using System;
using System.Collections.Generic;
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
        public float CalculateCurrentCourse(Vector2 previous_position, Vector2 current_position)
        {
            float course = 0.0f;

            //double X = Math.Abs(data.First.Value.X - data.Last.Value.X);
            //double Y = Math.Abs(data.First.Value.Y - data.Last.Value.Y);
            //double course = Math.Atan2(X, Y) * (180 / Math.PI);
            //if(data.First.Value.X > data.Last.Value.X && data.First.Value.Y <= data.Last.Value.Y) { course += 90; }
            //else if(data.First.Value.X <= data.Last.Value.X && data.First.Value.Y < data.Last.Value.Y) { course += 180; }
            //else if(data.First.Value.X < data.Last.Value.X && data.First.Value.Y > data.Last.Value.Y) { course += 270; }

            return course;
        }
    }
}
