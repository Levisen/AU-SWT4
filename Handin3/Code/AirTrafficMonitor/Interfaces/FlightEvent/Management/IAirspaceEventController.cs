﻿using AirTrafficMonitor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IEnterExitEventController
    {
        event EventHandler<EnterExitEventsUpdatedEventArgs> EnterExitEventsUpdated;
        int ScheduledDeactivationsCount { get; set; }
    }
}
