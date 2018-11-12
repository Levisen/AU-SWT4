using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceArea
    {
        public int SouthWestCornerX;
        public int SouthWestCornerY;
        public int NorthEastCornerX;
        public int NorthEastCornerY;
        public int AltitudeBoundaryLower;
        public int AltitudeBoundaryUpper;

        public AirspaceArea(int southWestCornerX, int southWestCornerY, int northEastCornerX, int northEastCornerY, int altitudeBoundaryLower, int altitudeBoundaryUpper)
        {
            SouthWestCornerX = southWestCornerX;
            SouthWestCornerY = southWestCornerY;
            NorthEastCornerX = northEastCornerX;
            NorthEastCornerY = northEastCornerY;
            AltitudeBoundaryLower = altitudeBoundaryLower;
            AltitudeBoundaryUpper = altitudeBoundaryUpper;
        }
    }
}
