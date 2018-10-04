using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightTrackerSingle
    {
        void AddDataPoint(FTDataPoint dp);
        FTDataPoint GetNewestDataPoint();
        ICollection<FTDataPoint> GetFullDataLog();
    }
}
