using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightEvent
    {
        string GetType();
        bool GetIsActive();
        List<string> GetInvolvedTags();
        DateTime GetActivationTime();
        DateTime GetDeactivationTime();
    }
}
