using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceArea : IAirspaceArea
    {
        private int SouthWestCornerX;
        private int SouthWestCornerY;
        private int NorthEastCornerX;
        private int NorthEastCornerY;
        private int AltitudeBoundaryLower;
        private int AltitudeBoundaryUpper;

        private Vector2 SouthWestCorner;
        private Vector2 NorthEastCorner;

        public AirspaceArea(int southWestCornerX, int southWestCornerY, int northEastCornerX, int northEastCornerY, int altitudeBoundaryLower, int altitudeBoundaryUpper)
        {
            SouthWestCornerX = southWestCornerX;
            SouthWestCornerY = southWestCornerY;
            NorthEastCornerX = northEastCornerX;
            NorthEastCornerY = northEastCornerY;
            AltitudeBoundaryLower = altitudeBoundaryLower;
            AltitudeBoundaryUpper = altitudeBoundaryUpper;

            SouthWestCorner = new Vector2(southWestCornerX, southWestCornerY);
            NorthEastCorner = new Vector2(northEastCornerX, northEastCornerY);
        }
        
        public bool IsInside(FTDataPoint dp)
        {
            if (dp.Altitude > AltitudeBoundaryLower && dp.Altitude < AltitudeBoundaryUpper
                && dp.X > SouthWestCornerX && dp.X < NorthEastCornerX
                && dp.Y > SouthWestCornerY && dp.Y < NorthEastCornerY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public float Heigth()
        {
            return NorthEastCornerY - SouthWestCornerY;
        }

        public float Width()
        {
            return NorthEastCornerX - SouthWestCornerX;
        }

        public Vector2 GetSouthWestCorner()
        {
            return SouthWestCorner;
        }

        public Vector2 GetNorthEastCorner()
        {
            return NorthEastCorner;
        }
    }
}
