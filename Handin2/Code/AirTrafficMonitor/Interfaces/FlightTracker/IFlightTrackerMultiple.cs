using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightTrackerMultiple
    {
        event EventHandler<MultipleFlightTracksUpdatedEventArgs> FlightTracksUpdated;
        IFlightTrackDataSource GetDataSource();
        //FTDataPoint GetNewestDataPoint();
        //FTDataPoint GetNewestDataPoint(string tag);
        //ICollection<FTDataPoint> GetAllFlights();
        //ICollection<FTDataPoint> GetAllFlights(string tag);
    }
}
