using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class SeperationEventDetector : ISeperationEventDetector
    {
        public event EventHandler<SeperationDetectedEventArgs> SeperationEventDetected;

        IFlightTrackManager _datasource;

        int _altitude;
        int _distance;
        public SeperationEventDetector(IFlightTrackManager flighttracker, int altitude = 300, int distance = 5000)
        {
            _datasource = flighttracker;
            _datasource.FlightTracksUpdated += OnFlightTracksUpdated;
            _altitude = altitude;
            _distance = distance;
        }


        private void OnAirspaceContentUpdated(object sender, AirspaceContentEventArgs e)
        {
            List<IFlightTrack> airspaceflights = e.AirspaceContent;
            CheckForSeperationEvents(airspaceflights);
        }

        private void OnFlightTracksUpdated(object sender, FlightTracksUpdatedEventArgs e)
        {
            List<IFlightTrack> allUpdatedFlights = e.UpdatedFlights;
            CheckForSeperationEvents(allUpdatedFlights);
        }

        private void CheckForSeperationEvents(List<IFlightTrack> flights)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                for (int j = i + 1; j < flights.Count; j++)
                {
                    IFlightTrack f1 = flights[i];
                    IFlightTrack f2 = flights[j];
                    if (TracksConflicting(f1, f2))
                    {
                        SeperationEvent detectedSeperation = new SeperationEvent(f1, f2);
                        SeperationEventDetected?.Invoke(this, new SeperationDetectedEventArgs(detectedSeperation));
                    }
                }
            }
        }

        public bool TracksConflicting(IFlightTrack f1, IFlightTrack f2)
        {
            double f1alt = f1.GetCurrentAltitude();
            double f2alt = f2.GetCurrentAltitude();
            Vector2 f1pos = f1.GetCurrentPosition();
            Vector2 f2pos = f2.GetCurrentPosition();

            if ((Math.Abs(f1alt - f2alt) < _altitude) && Vector2.Distance(f1pos, f2pos) < _distance)
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
