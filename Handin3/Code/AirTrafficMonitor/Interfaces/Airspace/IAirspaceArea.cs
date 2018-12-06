using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IAirspaceArea
    {
        bool IsInside(int x, int y, int alt);
        float Width();
        float Heigth();

        Vector2 GetSouthWestCorner();
        Vector2 GetNorthEastCorner();
    }
}
