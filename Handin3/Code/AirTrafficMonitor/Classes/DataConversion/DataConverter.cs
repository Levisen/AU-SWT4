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
    public class DataConverter: ITransponderDataConverter, IFlightTrackDataSource, ITransponderStringConverter
    {
        public event EventHandler<FlightTrackDataEventArgs> FlightTrackDataReady;
        ITransponderReceiver transponderReceiver;
        
        public DataConverter(ITransponderReceiver tr)
        {
            transponderReceiver = tr;
            transponderReceiver.TransponderDataReady += OnTransponderDataReady;
        }

        private void OnTransponderDataReady(object o, RawTransponderDataEventArgs args)
        {
            Debug.Log("DataReader: Handling TransponderDataReady Event");

            FlightTrackDataEventArgs flightTrackData = ConvertTransponderData(args);
            List<FTDataPoint> newFTDataPoints = flightTrackData.FTDataPoints;

            if (newFTDataPoints.Count > 0)
            {
                Debug.Log("DataReader: Invoking FlightTrackDataReady, sending " + newFTDataPoints.Count + " DataPoints:");
                foreach (var dp in newFTDataPoints)
                {
                    Debug.Log("Tag: " + dp.Tag + " Pos: " + dp.X + "," + dp.Y + " Altitude: " + dp.Altitude + " Time: " + dp.TimeStamp);
                }

                FlightTrackDataReady?.Invoke(this, flightTrackData);
            }
            else
            {
                Debug.Log("DataReader: No data to send");
            }
        }

        public FlightTrackDataEventArgs ConvertTransponderData(RawTransponderDataEventArgs args)
        {
            var DpList = new List<FTDataPoint>();
            
            foreach (var rawdatastring in args.TransponderData)
            {
                FTDataPoint dp = ConvertTransponderString(rawdatastring);
                DpList.Add(dp);
            }
            Debug.Log("DataReader: Converted " + DpList.Count + " strings");

            return new FlightTrackDataEventArgs(DpList);
        }

        public FTDataPoint ConvertTransponderString(string rawdata)
        {
            Console.WriteLine("RAWDATA: " + rawdata);
            //Todo: tilføj data validation (antal semikoloner, længde på elementer, allowed characters etc)
            var dp = new FTDataPoint();
            string[] splitdata = rawdata.Split(';');
            
            dp.Tag = splitdata[0];
            dp.X = Int32.Parse(splitdata[1]);
            dp.Y = Int32.Parse(splitdata[2]);
            dp.Altitude = Int32.Parse(splitdata[3]);
            dp.TimeStamp = DateTime.ParseExact(splitdata[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            return dp;
        }

        public ITransponderStringConverter GetStringConverter()
        {
            return this as ITransponderStringConverter;
        }

        public IFlightTrackDataSource GetFlightTrackDataSource()
        {
            return this as IFlightTrackDataSource;
        }
        public ITransponderReceiver GetTransponderReceiver()
        {
            return this as ITransponderReceiver;
        }
    }
}
