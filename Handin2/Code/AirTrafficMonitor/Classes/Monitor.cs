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
        IAirspace DataSource;

        public Monitor(IAirspace dataSource)
        {
            DataSource = dataSource;
            DataSource.AirspaceContentUpdated += OnAirspaceContentUpdated;
        }
        private void OnAirspaceContentUpdated(object o, AirspaceContentEventArgs args)
        {
            Debug.Log("Monitor: Handling TransponderDataReady Event");
            foreach (var f in args.UpdatedFlights)
            {
                FTDataPoint dp = f.GetNewestDataPoint();
                Console.WriteLine("Tag: " + dp.Tag + " Pos: " + dp.X + "," + dp.Y + " Altitude: " + dp.Altitude + " Time: " + dp.TimeStamp + " Velocity: ");
            }
        }
    }
}
