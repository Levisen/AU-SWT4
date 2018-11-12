using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor
{
    public class Monitor
    {
        IAirspace AirspaceDataSource;
        ISeperationManager SeperationEventDataSource;

        public Monitor(IAirspace airspaceDataSource, ISeperationManager seperationEventDataSource)
        {
            AirspaceDataSource = airspaceDataSource;
            AirspaceDataSource.AirspaceContentUpdated += OnAirspaceContentUpdated;
            SeperationEventDataSource = seperationEventDataSource;
            SeperationEventDataSource.SeperationEventsUpdated += OnSeperationEventsUpdated;
        }
        private void OnAirspaceContentUpdated(object o, AirspaceContentEventArgs args)
        {
            Debug.Log("Monitor: Handling TransponderDataReady Event");
            foreach (var f in args.UpdatedFlights)
            {
                FTDataPoint dp = f.GetNewestDataPoint();
                Console.WriteLine("Tag: " + dp.Tag + " Pos: " + dp.X + "," + dp.Y + " Altitude: " + dp.Altitude + " Time: " + dp.TimeStamp + " Velocity: " + f.GetCurrentVelocity() );
            }
        }

        private void OnSeperationEventsUpdated(object o, SeperationsUpdatedEventArgs args)
        {
            Debug.Log("Monitor: Handling TransponderDataReady Event");
            foreach (var f in args.ActiveSeperations)
            {
                Console.WriteLine("Active SeperationEvent between " + f.FlightA.GetTag() + " and " + f.FlightB.GetTag() + "started at time: " + f.TimeOfOccurance);
            }
        }
    }
}
