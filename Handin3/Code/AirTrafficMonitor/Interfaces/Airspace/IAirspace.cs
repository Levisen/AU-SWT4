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
        List<IFlightTrack> GetAirspaceContent();
        IAirspaceArea GetAirspaceArea();
        IFlightTrackManager GetDataSource();

        event EventHandler<AirspaceContentEventArgs> AirspaceContentUpdated;
    }
}
