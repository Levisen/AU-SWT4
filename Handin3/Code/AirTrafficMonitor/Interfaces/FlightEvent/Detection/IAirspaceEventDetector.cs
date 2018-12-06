using System;

namespace AirTrafficMonitor.Interfaces
{
    public interface IEnterExitEventDetector
    {
        event EventHandler<EnterExitEventDetectedArgs> EnterExitEventDetected;
    }
}