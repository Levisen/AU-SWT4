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
        private int _southWestCornerX;
        private int _southWestCornerY;
        private int _northEastCornerX;
        private int _northEastCornerY;
        private int _altitudeBoundaryLower;
        private int _altitudeBoundaryUpper;

        private Vector2 _southWestCorner;
        private Vector2 _northEastCorner;

        public AirspaceArea(int southWestCornerX, int southWestCornerY, int northEastCornerX, int northEastCornerY, int altitudeBoundaryLower, int altitudeBoundaryUpper)
        {
            _southWestCornerX = southWestCornerX;
            _southWestCornerY = southWestCornerY;
            _northEastCornerX = northEastCornerX;
            _northEastCornerY = northEastCornerY;
            _altitudeBoundaryLower = altitudeBoundaryLower;
            _altitudeBoundaryUpper = altitudeBoundaryUpper;

            _southWestCorner = new Vector2(southWestCornerX, southWestCornerY);
            _northEastCorner = new Vector2(northEastCornerX, northEastCornerY);
        }
        
        public bool IsInside(int x, int y, int alt)
        {
            if (alt > _altitudeBoundaryLower && alt < _altitudeBoundaryUpper
                && x > _southWestCornerX && x < _northEastCornerX
                && y > _southWestCornerY && y < _northEastCornerY)
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
            return _northEastCornerY - _southWestCornerY;
        }

        public float Width()
        {
            return _northEastCornerX - _southWestCornerX;
        }

        public Vector2 GetSouthWestCorner()
        {
            return _southWestCorner;
        }

        public Vector2 GetNorthEastCorner()
        {
            return _northEastCorner;
        }
    }
}
