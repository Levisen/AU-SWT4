using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
namespace AirTrafficMonitor
{
    class FlightController
    {
        List<Flight> Flights;
        public FlightController(IFlightTrackDataSource transponderReceiver) // 1. create datareader from main
        {
            transponderReceiver.FlightTrackDataReady += FlightTrackDataReady; // 2. void func to use when trigger
        }

        private void FlightTrackDataReady(object o, FlightTrackDataEventArgs args) //3 trigger use update from list
        {
            foreach (var dp in args.FTDataPoints)
            {
                if (Flights.Exists(x => x.Tag == dp.Tag))
                {
                    Flights.Add(new Flight(dp.Tag));
                }

                Flight f = Flights.Find(x => x.Tag == dp.Tag);
                
            }
        }

    }
}
