using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System.Globalization;
using TransponderReceiver;

namespace AirTrafficMonitor
{
    public class DataReader: ITransponderDataParser, ITransponderDataBundleReader, IFlightTrackDataSource
    {
        public event EventHandler<FlightTrackDataEventArgs> FlightTrackDataReady;  //eventhandler

        public DataReader(ITransponderReceiver transponderReceiver) // 1. create datareader from main
        {
            transponderReceiver.TransponderDataReady += TransponderDataReady; // 2. void func to use when trigger
        }

        private void TransponderDataReady(object o, RawTransponderDataEventArgs args) //3 trigger use update from list
        {
            Debug.Log("DataReader: Handling TransponderDataReady Event");

            List<FTDataPoint> newFTDataPoints = DecodeRawTransponderData(args);

            if (newFTDataPoints.Count > 0)
            {
                Debug.Log("DataReader: Invoking FlightTrackDataReady, sending " + newFTDataPoints.Count + " DataPoints:");
                foreach (var dp in newFTDataPoints)
                {
                    Debug.Log("Tag: " + dp.Tag + " Pos: " + dp.X + "," + dp.Y + " Altitude: " + dp.Altitude + " Time: " + dp.TimeStamp);
                }

                FlightTrackDataReady?.Invoke(this, new FlightTrackDataEventArgs(newFTDataPoints));
            }
            else
            {
                Debug.Log("DataReader: No data to send");
            }
        }

        public List<FTDataPoint> DecodeRawTransponderData(RawTransponderDataEventArgs args)
        {
            var DpList = new List<FTDataPoint>();
            
            foreach (var rawdatastring in args.TransponderData)
            {
                FTDataPoint dp = ParseTransponderDataString(rawdatastring);
                DpList.Add(dp);
            }
            Debug.Log("DataReader: Parsed " + DpList.Count + " strings");
            return DpList;
        }

        public FTDataPoint ParseTransponderDataString(string rawdata)
        {
            
            var dp = new FTDataPoint();
            string[] splitdata = rawdata.Split(';');
            
            dp.Tag = splitdata[0];
            dp.X = Int32.Parse(splitdata[1]);
            dp.Y = Int32.Parse(splitdata[2]);
            dp.Altitude = Int32.Parse(splitdata[3]);
            dp.TimeStamp = DateTime.ParseExact(splitdata[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            return dp;
        }


    }
}
