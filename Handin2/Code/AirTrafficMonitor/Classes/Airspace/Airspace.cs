using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor
{
    public class Airspace : IAirspace, IAirspaceAreaFilter
    {
        AirspaceArea AirspaceArea;
        List<Flight> Content;
        IFlightTrackerMultiple FlightTracker;

        public Airspace(IFlightTrackerMultiple flightTracker, AirspaceArea airspaceArea)
        {
            AirspaceArea = airspaceArea;
            Content = new List<Flight>();
            FlightTracker = flightTracker;
        }

        public event EventHandler<MultipleFlightTracksUpdatedEventArgs> FlightTracksUpdated;

        public List<Flight> GetAirspaceContent()
        {
            return Content;
        }

        public IFlightTrackerMultiple GetFlightTracker()
        {
            return FlightTracker;
        }

        public bool IsInsideAirspace(AirspaceArea area, FTDataPoint datapoint)
        {
            throw new NotImplementedException();
        }
    }
}
