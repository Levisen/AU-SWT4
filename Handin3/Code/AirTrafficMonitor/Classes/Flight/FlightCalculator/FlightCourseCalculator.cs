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
        public float CalculateCurrentCourse(Vector2 previous, Vector2 current)
        {

            float deltaX = current.X - previous.X;
            float deltaY = current.Y - previous.Y;
            double courseDegree = 0;

            if (deltaX == 0)
            {
                if (deltaY > 0) courseDegree = 0;
                else courseDegree = 180;
            }
            else
            {
                double radian = Math.Atan2(deltaY, deltaX);
                courseDegree = radian / Math.PI * 180;
                courseDegree = 90 - courseDegree;
                if (courseDegree < 0) courseDegree += 360;
            }
            return (float)courseDegree;
        }
    }
}
