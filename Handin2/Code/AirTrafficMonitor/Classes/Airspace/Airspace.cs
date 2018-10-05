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

        public bool IsInsideAirspace(FTDataPoint dp, AirspaceArea area)
        {
            if (dp.Altitude > area.AltitudeBoundaryLower && dp.Altitude < area.AltitudeBoundaryUpper
                && dp.X > area.SouthWestCornerX && dp.X < area.NorthEastCornerX
                && dp.Y > area.SouthWestCornerY && dp.Y < area.NorthEastCornerY)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
