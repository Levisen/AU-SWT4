﻿using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class SeperationEvent : FlightEvent
    {
        public IFlightTrackerSingle Flight_A { get; set; }
        public IFlightTrackerSingle Flight_B { get; set; }

        public SeperationEvent(IFlightTrackerSingle flight_A, IFlightTrackerSingle flight_B) 
            : base ("Seperation", flight_A.GetTag() + " and " + flight_B.GetTag())
        {
            Flight_A = flight_A;
            Flight_B = flight_B;
        }
    }
}
