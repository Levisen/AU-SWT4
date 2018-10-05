using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    public class SeperationController : ISeperationDetector
    {
        IFlightTrackerMultiple FlightTracker;
        List<SeperationEventArgs> ActiveSeperations;
        public event EventHandler<SeperationEventArgs> SeperationIdentified;

        public SeperationController(IFlightTrackerMultiple flightTracker)
        {
            ActiveSeperations = new List<SeperationEventArgs>();
            FlightTracker = flightTracker;
            FlightTracker.FlightTracksUpdated += OnFlightTracksUpdated;
        }

        private void OnFlightTracksUpdated(object o, MultipleFlightTracksUpdatedEventArgs args)
        {
            List<IFlightTrackerSingle> allUpdatedFlights = args.UpdatedFlights;
            for (int i = 0; i < allUpdatedFlights.Count; i++)
            {
                IFlightTrackerSingle f1 = allUpdatedFlights[i];
                for (int j = i + 1; j < allUpdatedFlights.Count; j++)
                {
                    IFlightTrackerSingle f2 = allUpdatedFlights[j];

                    SeperationEventArgs detectedSeperation = CheckForSeperationEvent(f1, f2);
                    if (detectedSeperation != null && !ActiveSeperations.Contains(detectedSeperation))
                    {
                        ActiveSeperations.Add(detectedSeperation);
                        SeperationIdentified?.Invoke(this, detectedSeperation);

                    }
                }
            }

        }
        public SeperationEventArgs CheckForSeperationEvent(IFlightTrackerSingle f1, IFlightTrackerSingle f2)
        {
            float f1alt = f1.GetCurrentAltitude();
            float f2alt = f2.GetCurrentAltitude();
            Vector2 f1pos = f1.GetCurrentPosition();
            Vector2 f2pos = f2.GetCurrentPosition();

            if ((Math.Abs(f1alt - f2alt) < 300) && Vector2.Distance(f1pos, f2pos) < 5000)
            {
                return new SeperationEventArgs(f1, f2, DateTime.Now);
            }
            else
            {
                return null;
            }
        }
    }
}
