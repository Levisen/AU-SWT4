using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class EnterExitEventDetector : IEnterExitEventDetector
    {
        public event EventHandler<EnterExitEventDetectedArgs> EnterExitEventDetected;
        
        private IFlightTrackManager _datasource;
        private List<IFlightTrack> previous;

        public EnterExitEventDetector(IFlightTrackManager airspace)
        {
            previous = new List<IFlightTrack>();
            _datasource = airspace;
            _datasource.FlightTracksUpdated += OnAirspaceContentUpdated;
        }

        private void OnAirspaceContentUpdated(object sender, FlightTracksUpdatedEventArgs e)
        {
            var newflights = e.UpdatedFlights;
            
            if (newflights.Count > 0 || previous.Count > 0)
            {
                //Check for enter events
                foreach (var newf in newflights)
                {
                    if (!previous.Any(x => x.GetTag() == newf.GetTag()))
                    {
                        EnterExitEvent newevent = new EnterExitEvent(newf, true);
                        EnterExitEventDetected?.Invoke(this, new EnterExitEventDetectedArgs(newevent));
                    }
                }
                //Check for exit events
                foreach (var oldf in previous)
                {
                    if (!newflights.Any(x => x.GetTag() == oldf.GetTag()))
                    {
                        EnterExitEvent newevent = new EnterExitEvent(oldf, false);
                        EnterExitEventDetected?.Invoke(this, new EnterExitEventDetectedArgs(newevent));
                    }
                }
            }
            previous.Clear();
            previous.AddRange(newflights);
        }
    }
}
