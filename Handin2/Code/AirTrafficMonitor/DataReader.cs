using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using System.Globalization;
using TransponderReceiver;

namespace AirTrafficMonitor
{
    public class DataReader: ITransponderDataParser, ITransponderDataBundleReader
    {
        //public event EventHandler<DataReaderChangedEventArgs> EventDataTrackChanged;  //eventhandler
        public DataReader(ITransponderReceiver transponderReceiver) // 1. create datareader from main
        {
            transponderReceiver.TransponderDataReady += TransponderDataReady; // 2. void func to use when trigger
        }

        private void TransponderDataReady(object o, RawTransponderDataEventArgs args) //3 trigger use update from list
        {
<<<<<<< HEAD
            _dataTrack.Clear();
            foreach(var data in args.TransponderData)
=======
            List<FTDataPoint> NewFTDataPoints = DecodeRawTransponderData(args);

            if (NewFTDataPoints.Count > 0)
>>>>>>> Gill
            {
                Monitor m = new Monitor();
                foreach (var dp in NewFTDataPoints)
                {
                    m.OutputFTDataPoint(dp);
                }
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
