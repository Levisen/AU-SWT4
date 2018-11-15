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
            double result = 0;

            //var t = new LinkedList<FTDataPoint>(data);
            //var xPos = new LinkedList<int>(); var yPos = new LinkedList<int>();
            //var velocityResults = new LinkedList<double>();
            //double t1, t2, distance, result = 0, resultDouble;
            //float finalResult;
            //foreach(var item in t) { xPos.AddLast(item.X); yPos.AddLast(item.Y); }
            //while (t.First != t.Last) {
            //    distance = Math.Sqrt(Math.Pow(t.First.Value.X - t.First.Next.Value.X, 2) 
            //             + Math.Pow(t.First.Value.Y - t.First.Next.Value.Y, 2));
            //    t1 = t.First.Value.TimeStamp.Second; t2 = t.First.Value.TimeStamp.Second;
            //    velocityResults.AddLast(distance / (t2 - t1));
            //    t.RemoveFirst(); }
            //foreach (var item in velocityResults) { result = +item; }
            //resultDouble = result / velocityResults.Count;
            //finalResult = (float)resultDouble;
            //return finalResult;

            return result;
        }
    }
}
