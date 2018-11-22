using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IFlightCourseCalculator
    {
        double CalculateCurrentCourse(Vector2 previous, Vector2 current);
    }
}
