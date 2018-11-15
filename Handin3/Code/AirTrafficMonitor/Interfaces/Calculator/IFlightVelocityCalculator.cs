using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightVelocityCalculator
    {
        double CalculateCurrentVelocity(Vector2 previous_position, DateTime? previous_timestamp, Vector2 current_position, DateTime current_timestamp);
    }
}
