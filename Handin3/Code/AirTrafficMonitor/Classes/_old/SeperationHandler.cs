using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System.Threading;

namespace AirTrafficMonitor
{
    public class SeperationHandler
    {
        //ISeperationDetector Detector;
        //IFlightTrackerMultiple Tracker;

        ////ManualResetEvent SeperationResolvedSignal;
        //public SeperationHandler(ISeperationDetector detector, IFlightTrackerMultiple tracker)
        //{
        //    Detector = detector;
        //    Detector.SeperationIdentified += OnSeperationIdentified;
        //    Tracker = tracker;
            
        //    //SeperationResolvedSignal = new ManualResetEvent(false);
        //}
        

        //private void OnSeperationIdentified(object o, SeperationEventArgs args)
        //{
        //    Debug.Log("SeperationHandler: Handling SeperationIdentified Event");
        //    //if (Detector.GetActiveSeperations().Count > 0)
        //    //{
        //    //    Tracker.FlightTracksUpdated += OnFlightTracksUpdated;
        //    //}

        //    //while (args.HasSameTagsAs())
        //    //{

        //    //}
        //    //SeperationResolvedSignal.WaitOne(); //This thread will block here until the reset event is sent.
        //    //SeperationResolvedSignal.Reset();

        //    //
        //}
        //private void OnFlightTracksUpdated(object o, MultipleFlightTracksUpdatedEventArgs args)
        //{
        //    //List<IFlightTrackerSingle> allUpdatedFlights = args.UpdatedFlights;
        //    //List<SeperationEventArgs> activeSeps = Detector.GetActiveSeperations();

        //    //if (activeSeps.Count == 0){ return; }

        //    //bool seperationResolved = false;
        //    //int resolvedSeperationIndex = -1;
        //    //foreach (var sepEvent in activeSeps)
        //    //{
        //    //    for (int i = 0; i < allUpdatedFlights.Count; i++)
        //    //    {
        //    //        for (int j = i + 1; j < allUpdatedFlights.Count; j++)
        //    //        {
        //    //            IFlightTrackerSingle f1 = allUpdatedFlights[i];
        //    //            IFlightTrackerSingle f2 = allUpdatedFlights[j];
        //    //            if (sepEvent.HasSameTagsAs(f1, f2))
        //    //            {
        //    //                if (Detector.CheckForSeperationEvent(f1, f2) == null)
        //    //                {
        //    //                    seperationResolved = true;
        //    //                    resolvedSeperationIndex = activeSeps.FindIndex(x => x.HasSameTagsAs(f1, f2));
        //    //                    Debug.Log("SeperationHandler: Seperation Resolved");
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    //if (seperationResolved)
        //    //{
        //    //    activeSeps.RemoveAt(resolvedSeperationIndex);
        //    //    Tracker.FlightTracksUpdated -= OnFlightTracksUpdated;
        //    //}




        //}
    }
}
