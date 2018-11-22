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

            //ISeperationManager seperationController = new SeperationController(flightManager);
            //SeperationHandler sepHandl = new SeperationHandler(seperationController, flightManager);

            IAirspace airspace = new Airspace(flightManager, area);

            ISeperationEventDetector seperationDetector = new SeperationEventDetector(flightManager);

            //ISeperationEventController flightEventController = new FlightEventController(flightManager);
            IAirspaceEventController airspaceEventCtrl = new AirspaceEventController();
            ISeperationEventController seperationEventCtrl = new SeperationEventController(seperationDetector);

            var updatetriggers = new List<EventHandler>();
            //updatetriggers.Add(airspace.AirspaceContentUpdated);

            IMonitor monitor = new Monitor();

            var airspaceContentDisplayer = new AirspaceContentDisplayer(monitor, airspace);
            var aispaceEventDisplayer = new AirspaceEventDisplayer(monitor, airspaceEventCtrl);
            var seperationEventDisplayer = new SeperationEventDisplayer(monitor, seperationEventCtrl);

            //Monitor monitor = new Monitor(airspace, seperationController);
            while (true)
            {
                Thread.Sleep(150);
            };
        }
    }
}
