using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class FlightEvent
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public List<IFlightTrack> InvolvedFlights { get; set; }

        public DateTime ActivationTime { get; set; }

        public DateTime? DeactivationTime { get; set; }

        public FlightEvent(string type, string description)
        {
            Type = type;
            Description = description;
            IsActive = true;
            ActivationTime = DateTime.Now;
            DeactivationTime = null;
        }
    }
}
