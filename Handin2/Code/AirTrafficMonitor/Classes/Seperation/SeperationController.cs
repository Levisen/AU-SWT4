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
    public class SeperationController : ISeperationDetector, ISeperationManager, ISeperaionHandler
    {
        IFlightTrackerMultiple FlightTracker;
        List<SeperationEventArgs> ActiveSeperations;
        public event EventHandler<SeperationEventArgs> SeperationIdentified;

        public event EventHandler<SeperationsUpdatedEventArgs> SeperationEventsUpdated;

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
                for (int j = i + 1; j < allUpdatedFlights.Count; j++)
                {
                    IFlightTrackerSingle f1 = allUpdatedFlights[i];
                    IFlightTrackerSingle f2 = allUpdatedFlights[j];
                    SeperationEventArgs detectedSeperation = CheckForSeperationEvent(f1, f2);
                    if (detectedSeperation != null)
                    {
                        Debug.Log("Current SeperationEvent between " + detectedSeperation.FlightA.GetTag() + " and " + detectedSeperation.FlightB.GetTag() + "started at time: " + detectedSeperation.TimeOfOccurance);
                        if (!ActiveSeperations.Exists(x => x.HasSameTagsAs(detectedSeperation)))
                        {
                            Console.WriteLine("A SeperationEvent has just been identified" + detectedSeperation.FlightA.GetTag() + " and " + detectedSeperation.FlightB.GetTag() + "started at time: " + detectedSeperation.TimeOfOccurance);
                            ActiveSeperations.Add(detectedSeperation);
                            //SeperationIdentified?.Invoke(this, detectedSeperation);
                            SeperationsUpdatedEventArgs a = new SeperationsUpdatedEventArgs(ActiveSeperations);
                            SeperationEventsUpdated?.Invoke(this, a);
                        }
                        else
                        {
                            //Debug.Log("SeperationController: SeperationEvent still going on, somebody do something!");
                        }
                    }
                }
            }
            
            if (ActiveSeperations.Count > 0)
            {
                bool seperationResolved = false;
                int resolvedSeperationIndex = -1;
                foreach (var sepEvent in ActiveSeperations)
                {
                    for (int i = 0; i < allUpdatedFlights.Count; i++)
                    {
                        for (int j = i + 1; j < allUpdatedFlights.Count; j++)
                        {
                            IFlightTrackerSingle f1 = allUpdatedFlights[i];
                            IFlightTrackerSingle f2 = allUpdatedFlights[j];
                            if (sepEvent.HasSameTagsAs(f1, f2))
                            {
                                if (CheckForSeperationEvent(f1, f2) == null)
                                {
                                    resolvedSeperationIndex = ActiveSeperations.FindIndex(x => x.HasSameTagsAs(f1, f2));
                                    Debug.Log("SeperationHandler: Seperation between" + sepEvent.FlightA.GetTag() + " and " + sepEvent.FlightB.GetTag() + " resolved!");
                                }
                            }
                        }
                    }
                }
                if (seperationResolved)
                {
                    ActiveSeperations.RemoveAt(resolvedSeperationIndex);
                }
            }
            if (ActiveSeperations.Count == 0)
            {

            }
            else
            {
                Console.WriteLine("---------------------Current Seperation Events:------------------- ");
                foreach (var f in ActiveSeperations) //Should be in monitor
                {
                    Console.WriteLine("SeperationEvent involving " + f.FlightA.GetTag() + " and " + f.FlightB.GetTag() + ", started at time: " + f.TimeOfOccurance);
                }
            }
            

        }
        public SeperationEventArgs CheckForSeperationEvent(IFlightTrackerSingle f1, IFlightTrackerSingle f2)
        {
            float f1alt = f1.GetCurrentAltitude();
            float f2alt = f2.GetCurrentAltitude();
            Vector2 f1pos = f1.GetCurrentPosition();
            Vector2 f2pos = f2.GetCurrentPosition();

            if ((Math.Abs(f1alt - f2alt) < 3000) && Vector2.Distance(f1pos, f2pos) < 15000)
            {
                return new SeperationEventArgs(f1, f2, DateTime.Now);
            }
            else
            {
                return null;
            }
        }

        public List<SeperationEventArgs> GetActiveSeperations()
        {
            return ActiveSeperations;
        }
    }
}
