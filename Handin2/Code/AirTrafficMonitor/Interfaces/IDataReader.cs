using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public class DataReaderChangedEventArgs : EventArgs //9. this will run as eventargument
    {
        public List<DataEntry> _trackData { get; set; }

        public DataReaderChangedEventArgs(List<DataEntry> t)
        {
            _trackData = t;
        }
    }
    public interface IDataReader
    {
        event EventHandler<DataReaderChangedEventArgs> EventDataTrackChanged;
        DataEntry DataReaderSplit(string trackdata);
    }
}
