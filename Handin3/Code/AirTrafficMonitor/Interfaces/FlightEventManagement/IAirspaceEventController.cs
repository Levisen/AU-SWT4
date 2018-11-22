using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IAirspaceEventController
    {
        event EventHandler<AirspaceEventsUpdatedEventArgs> AirspaceEventsUpdated;
    }
}
