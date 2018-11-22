using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface ISeperationEventDetector
    {
        event EventHandler<SeperationDetectedEventArgs> SeperationEventDetected;
        bool TracksConflicting(IFlightTrackerSingle f1, IFlightTrackerSingle f2);
    }
}
