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
            IFlightTrackerMultiple flightManager = new FlightManager(dataConverter);


            while (true)
            {
                Thread.Sleep(500);
            };
        }
    }
}
