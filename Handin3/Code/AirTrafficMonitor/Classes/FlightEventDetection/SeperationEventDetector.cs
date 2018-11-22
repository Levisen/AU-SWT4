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

        IFlightTrackerMultiple _datasource;
        public SeperationEventDetector(IFlightTrackerMultiple flighttracker)
        {
            _datasource = flighttracker;
            _datasource.FlightTracksUpdated += OnFlightTracksUpdated;
        }

        private void OnFlightTracksUpdated(object sender, FlightTracksUpdatedEventArgs e)
        {
            List<IFlightTrackerSingle> allUpdatedFlights = e.UpdatedFlights;
            for (int i = 0; i < allUpdatedFlights.Count; i++)
            {
                for (int j = i + 1; j < allUpdatedFlights.Count; j++)
                {
                    IFlightTrackerSingle f1 = allUpdatedFlights[i];
                    IFlightTrackerSingle f2 = allUpdatedFlights[j];
                    if (TracksConflicting(f1, f2))
                    {
                        SeperationEvent detectedSeperation = new SeperationEvent(f1, f2);

                        //Debug.Log("Current SeperationEvent between " + detectedSeperation.FlightA.GetTag() + " and " + detectedSeperation.FlightB.GetTag() + "started at time: " + detectedSeperation.TimeOfOccurance);

                        //if (!ActiveSeperations.Exists(x => x.HasSameTagsAs(detectedSeperation)))
                        //{
                        //    Console.WriteLine("A SeperationEvent has just been identified" + detectedSeperation.FlightA.GetTag() + " and " + detectedSeperation.FlightB.GetTag() + "started at time: " + detectedSeperation.TimeOfOccurance);
                        //    ActiveSeperations.Add(detectedSeperation);
                        //    //SeperationIdentified?.Invoke(this, detectedSeperation);
                        //    SeperationsUpdatedEventArgs a = new SeperationsUpdatedEventArgs(ActiveSeperations);
                        //    SeperationEventsUpdated?.Invoke(this, a);
                        //}
                        //else
                        //{
                        //    //Debug.Log("SeperationController: SeperationEvent still going on, somebody do something!");
                        //}
                    }
                }
            }


        }

        public bool TracksConflicting(IFlightTrackerSingle f1, IFlightTrackerSingle f2)
        {
            double f1alt = f1.GetCurrentAltitude();
            double f2alt = f2.GetCurrentAltitude();
            Vector2 f1pos = f1.GetCurrentPosition();
            Vector2 f2pos = f2.GetCurrentPosition();

            if ((Math.Abs(f1alt - f2alt) < 3000) && Vector2.Distance(f1pos, f2pos) < 15000)
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
