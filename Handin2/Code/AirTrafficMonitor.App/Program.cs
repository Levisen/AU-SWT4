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
            var dataReader = new DataReader(transponderReceiver);

            //testprint
            while (true)
            {
                Thread.Sleep(500);

                //transponderDataSplitterToTrackData.
            };
        }
    }
}
