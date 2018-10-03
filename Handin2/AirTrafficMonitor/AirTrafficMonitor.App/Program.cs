using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            var transponderDataSplitterToTrackData = new DataReader(transponderReceiver);

            //testprint
            while (true)
            {
                Thread.Sleep(500);

                transponderDataSplitterToTrackData._dataTrack.ForEach(item => Console.Write(
                  "Transponderdata: " + item.Tag
                + "   Position: " + item.X + "," + item.Y
                + "   Altitude: " + item.Altitude
                + "   Time: " + item.TimeStamp
                + Environment.NewLine));
            };
        }
    }
}
