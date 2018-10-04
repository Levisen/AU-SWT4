using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor.Interfaces
{
    public interface ITransponderDataBundleReader
    {
        //List<FTDataPoint> DecodeRawTransponderDataBundle(List<string> rawdatabundle);
        List<FTDataPoint> DecodeRawTransponderData(RawTransponderDataEventArgs args);
    }
}
