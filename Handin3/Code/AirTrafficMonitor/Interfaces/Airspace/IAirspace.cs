using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Interfaces
{
    public interface IAirspace
    {
        List<IFlightTrackerSingle> GetAirspaceContent();
        IAirspaceArea GetAirspaceArea();
        IFlightTrackerMultiple GetFlightTracker();

        event EventHandler<AirspaceContentEventArgs> AirspaceContentUpdated;
    }
}
