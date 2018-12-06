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
            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            IFlightTrackDataSource dataConverter = new DataConverter(transponderReceiver);
            IFlightTrackManager flightManager = new SensorAreaManager(dataConverter);

            var airspace = new AirspaceManager(flightManager, new AirspaceArea(10000, 10000, 90000, 90000, 500, 20000));
            
            IEnterExitEventDetector airspacEnterExitEventDetector = new EnterExitEventDetector(airspace);
            IEnterExitEventController airspaceEnterExitEventCtrl = new EnterExitEventController(airspacEnterExitEventDetector);

            ISeperationEventDetector airspaceSeperationDetector = new SeperationEventDetector(airspace, 300, 5000);
            //ISeperationEventDetector seperationDetector = new SeperationEventDetector(flightManager, 5000, 10000);
            ISeperationEventController airspaceSeperationEventCtrl = new SeperationEventController(airspaceSeperationDetector);

            IMonitor monitor = new Monitor();
            var airspaceContentDisplayer = new AirspaceContentDisplayer(monitor, airspace, 40, 20);
            var aispaceEventDisplayer = new EnterExitEventDisplayer(monitor, airspaceEnterExitEventCtrl);
            var seperationEventDisplayer = new SeperationEventDisplayer(monitor, airspaceSeperationEventCtrl);

            while (true)
            {
                Thread.Sleep(250);
            };
        }
    }
}
