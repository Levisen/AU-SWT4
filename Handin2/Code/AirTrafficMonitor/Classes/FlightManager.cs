using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
namespace AirTrafficMonitor
{
    public class FlightManager
    {
        List<Flight> Flights;
        public FlightManager(IFlightTrackDataSource transponderReceiver) // 1. create datareader from main
        {
            transponderReceiver.FlightTrackDataReady += FlightTrackDataReady; // 2. void func to use when trigger
            Flights = new List<Flight>();
        }

        private void FlightTrackDataReady(object o, FlightTrackDataEventArgs args) //3 trigger use update from list
        {
            Debug.Log("FlightManager: Handling FlightTrackDataReady event, recieved " + args.FTDataPoints.Count + " Datapoints");
            List<FTDataPoint> recievedDataPoints = args.FTDataPoints;
            
            foreach (var dp in args.FTDataPoints)
            {
                if (!Flights.Exists(x => x.Tag == dp.Tag))
                {
                    Debug.Log("FlightManager: New flight entered sensor range with tag '" + dp.Tag + "'");
                    Flights.Add(new Flight(dp.Tag));
                }

                Flight f = Flights.Find(x => x.Tag == dp.Tag);
                f.AddDataPoint(dp);
            }
        }

    }
}
