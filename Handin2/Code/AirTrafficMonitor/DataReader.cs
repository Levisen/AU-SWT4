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
    public class DataReader: IDataReader
    {
        public event EventHandler<DataReaderChangedEventArgs> EventDataTrackChanged;  //eventhandler
        public List<DataEntry> _dataTrack;
        public DataReader(ITransponderReceiver transponderReceiver) // 1. create datareader from main
        {
            _dataTrack = new List<DataEntry>();
            transponderReceiver.TransponderDataReady += UpdateDataReceived; // 2. void func to use when trigger
        }
        private void UpdateDataReceived(object o, RawTransponderDataEventArgs args) //3 trigger use update from list
        {
            _dataTrack.Clear();
            args.TransponderData.ElementAt(1);
            foreach(var data in args.TransponderData)
            {
                var d = DataReaderSplit(data); //4. run data splitter for each in list
                _dataTrack.Add(d);
            }
            if (_dataTrack.Count != 0)
            {
                var h = EventDataTrackChanged; //7. case: eventhandler need to invoke an event, including _datatracker in Idatareader, to pass object
                h?.Invoke(this, new DataReaderChangedEventArgs(_dataTrack));    //5. case transponderreceiver get a new event, 
            }                                                                   
        }                                                                       
        public DataEntry DataReaderSplit(string trackdata) //6. use split function
        {
            string[] Data = trackdata.Split(';');
            DataEntry trackDataSplitted = new DataEntry();
            trackDataSplitted.Tag = Data[0];
            trackDataSplitted.X = Int32.Parse(Data[1]);
            trackDataSplitted.Y = Int32.Parse(Data[2]);
            trackDataSplitted.Altitude = Int32.Parse(Data[3]);
            trackDataSplitted.TimeStamp = DateTime.ParseExact(Data[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            return trackDataSplitted;
        }
    }
}
