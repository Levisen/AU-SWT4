using System;

namespace AirTrafficMonitor.Interfaces
{
    public interface IAirspaceEventDetector
    {
        event EventHandler<AirspaceEventDetectedArgs> AirspaceEventDetected;
    }
}