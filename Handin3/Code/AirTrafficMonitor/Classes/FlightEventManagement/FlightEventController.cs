using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class FlightEventController
    {
        List<IFlightEvent> _activeevents;
        List<IFlightEvent> _inactiveevents;

        IFlightTrackerMultiple FlightTracker;
        //List<IFlightEvent> FlightEvents;

        public event EventHandler<FlightEventsUpdatedEventArgs> FlightEventsUpdated;

        public FlightEventController(IFlightTrackerMultiple flightTracker)
        {
            _activeevents = new List<IFlightEvent>();
            _inactiveevents = new List<IFlightEvent>();

            //FlightEvents = flightEvents;
            FlightTracker = flightTracker;

            FlightTracker.FlightTracksUpdated += OnFlightTracksUpdated;
        }



        private void OnFlightTracksUpdated(object sender, FlightTracksUpdatedEventArgs args)
        {
            var activeevents = new List<IFlightEvent>();

            List<IFlightTrackerSingle> updatedflights = args.UpdatedFlights;

            foreach (var flight in updatedflights)
            {
                //fe.CheckForEvent(updatedFlights);
            }

            _activeevents = activeevents;
            FlightEventsUpdated?.Invoke(this, new FlightEventsUpdatedEventArgs(_activeevents));
        }

        /*
         *  Seperation Event
         *      TimeDate
         *      Involved Flights
         *      
         *      
         *      Criteria For Activation 
         *          Seperation: 
         *              Input - List Of Flights
         *              Output - A) Call identify 
         *              
         *              
         *  FlightEvent
         *      Name
         *      
         *      List active
         *      List inactive
         *      
         *      Method for identifying event activation criteria
         *          Seperation
         *          AirspaceEnter
         *          AirspaceLeave
         *          
         *  FlightEventController
         *      EventsUpdated
         *      
         */
    }
}
