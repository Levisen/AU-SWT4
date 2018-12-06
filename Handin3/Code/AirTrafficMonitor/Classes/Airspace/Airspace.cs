using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor
{
    public class Airspace : IAirspace
    {
        IAirspaceArea AirspaceArea;
        IFlightTrackerMultiple FlightTracker;

        List<IFlightTrackerSingle> Content;
        public event EventHandler<AirspaceContentEventArgs> AirspaceContentUpdated;

        public Airspace(IFlightTrackerMultiple flightTracker, IAirspaceArea airspaceArea)
        {
            AirspaceArea = airspaceArea;
            Content = new List<IFlightTrackerSingle>();
            FlightTracker = flightTracker;
            FlightTracker.FlightTracksUpdated += OnFlightTracksUpdated;
        }

        private void OnFlightTracksUpdated(object o, FlightTracksUpdatedEventArgs args)
        {
            List<IFlightTrackerSingle> allUpdatedFlights = args.UpdatedFlights;

            Content.Clear();

            foreach (var f in allUpdatedFlights)
            {
                var pos = f.GetCurrentPosition();
                if (AirspaceArea.IsInside((int)pos.X, (int)pos.Y, (int)f.GetCurrentAltitude()))
                {
                    Content.Add(f);
                }
            }

            AirspaceContentUpdated?.Invoke(this, new AirspaceContentEventArgs(Content));
        }

        public List<IFlightTrackerSingle> GetAirspaceContent()
        {
            return Content;
        }

        public IFlightTrackerMultiple GetFlightTracker()
        {
            return FlightTracker;
        }



        public IAirspaceArea GetAirspaceArea()
        {
            return AirspaceArea;
        }
    }
}
