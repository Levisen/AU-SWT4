using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;
using AirTrafficMonitor.Interfaces;
using System.Diagnostics;

namespace AirTrafficMonitor.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            AirspaceArea area = new AirspaceArea(10000, 10000, 90000, 90000, 500, 20000);

            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            IFlightTrackDataSource dataConverter = new DataConverter(transponderReceiver);
            IFlightTrackerMultiple flightManager = new FlightManager(dataConverter);

            ISeperationDetector seperationController = new SeperationController(flightManager);
            IAirspace airspace = new Airspace(flightManager, area);

            Monitor monitor = new Monitor(airspace);
            while (true)
            {
                Thread.Sleep(150);
            };
        }
    }
}
