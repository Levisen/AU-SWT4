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
            #if DEBUG

            #endif
            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            IFlightTrackDataSource dataReader = new DataReader(transponderReceiver);
            var flightController = new FlightManager(dataReader);

            //testprint
            while (true)
            {
                Thread.Sleep(500);

                //transponderDataSplitterToTrackData.
            };
        }
    }
}
