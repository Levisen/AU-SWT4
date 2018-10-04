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
        List<IFlightTrackerSingle> Content;
        IFlightTrackerMultiple FlightTracker;

        public event EventHandler<AirspaceContentEventArgs> AirspaceContentUpdated;
        public Airspace(IFlightTrackerMultiple flightTracker, AirspaceArea airspaceArea)
        {
            AirspaceArea = airspaceArea;
            Content = new List<IFlightTrackerSingle>();
            FlightTracker = flightTracker;
            FlightTracker.FlightTracksUpdated += OnFlightTracksUpdated;
        }

        public event EventHandler<MultipleFlightTracksUpdatedEventArgs> FlightTracksUpdated;
        private void OnFlightTracksUpdated(object o, MultipleFlightTracksUpdatedEventArgs args)
        {
            List<IFlightTrackerSingle> allUpdatedFlights = args.UpdatedFlights;

            Content.Clear();

            foreach (var f in allUpdatedFlights)
            {
                if (IsInsideAirspace(f.GetNewestDataPoint(), AirspaceArea))
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

        public bool IsInsideAirspace(FTDataPoint datapoint, AirspaceArea area)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
