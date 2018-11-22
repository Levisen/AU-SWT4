using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    public class FlightVelocityCalculator : IFlightVelocityCalculator
    {
        public double CalculateCurrentVelocity(Vector2 previous_position, DateTime? previous_timestamp, Vector2 current_position, DateTime current_timestamp)
        { 

            double distance, deltaY, deltaX;
            if (current_position.X > previous_position.X) deltaX = current_position.X - previous_position.X;
            else deltaX = previous_position.X - current_position.X;
            if (current_position.Y > previous_position.Y) deltaY = current_position.Y - previous_position.Y;
            else deltaY = previous_position.Y - current_position.Y;
            distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            double timeBetweenInSeconds;
            var DatetimeToTimeStamp = new DateTime();
            TimeSpan current, previous, resultTimespan;
            current = DatetimeToTimeStamp.Subtract(current_timestamp);
            previous = DatetimeToTimeStamp.Subtract(previous_timestamp ?? DateTime.Now);
            resultTimespan = current - previous;
            timeBetweenInSeconds = (double)resultTimespan.TotalSeconds;
            if (timeBetweenInSeconds < 0)
            {
                timeBetweenInSeconds = timeBetweenInSeconds * -1; //convert to positive
            }
            return (distance / timeBetweenInSeconds);
        }
    }
}
