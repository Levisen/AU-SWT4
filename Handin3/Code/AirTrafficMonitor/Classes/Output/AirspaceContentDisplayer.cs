using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor
{
    public class AirspaceContentDisplayer
    {
        private IAirspace _airspace;
        private IMonitor _monitor;

        private int grid_width;
        private int grid_heigth;

        public AirspaceContentDisplayer(IMonitor monitor, IAirspace airspace, int grid_width = 40, int grid_heigth = 20) 
        {
            _airspace = airspace;
            _monitor = monitor;
            this.grid_width = grid_width;
            this.grid_heigth = grid_heigth;

            _airspace.AirspaceContentUpdated += OnAirspaceContentUpdated;
        }

        private void OnAirspaceContentUpdated(object sender, AirspaceContentEventArgs e)
        {
            List<IFlightTrackerSingle> flights = e.AirspaceContent;

            var gridstring = GenerateAirspaceGrid(flights);
            
            var flightliststring = GenerateAirspaceFlightList(flights);

            _monitor.UpdateDisplaySection("AirspaceGrid", gridstring);
            _monitor.UpdateDisplaySection("AirspaceFlightList", flightliststring);

        }

        public string GenerateAirspaceFlightList(List<IFlightTrackerSingle> flights)
        {
            string airspaceflightlist = "-FLIGHTS-IN-AIRSPACE-\n";
            airspaceflightlist += "TAG\tPOSX\tPOSY\tALT\tTIME\tVEL\tCOURSE\n";

            foreach (var flight in flights)
            {
                FTDataPoint dp = flight.GetNewestDataPoint();
                airspaceflightlist += dp.Tag + "\t"
                                    + dp.X + "\t"
                                    + dp.Y + "\t"
                                    + dp.Altitude + "\t"
                                    + dp.TimeStamp.ToShortTimeString() + "\t"
                                    + flight.GetCurrentVelocity().ToString("0.00") + "\t"
                                    + flight.GetCurrentCourse().ToString("0.00") + "\n";
            }

            return airspaceflightlist;
        }

        public string GenerateAirspaceGrid(List<IFlightTrackerSingle> flights)
        {
            string airspacegrid = "-AIRSPACE-GRID-\n";

            var dps = new List<FTDataPoint>();
            flights.ForEach(f => dps.Add(f.GetNewestDataPoint()));

            //empty grid
            char[,] grid = new char[grid_heigth, grid_width];
            for (int i = 0; i < grid_heigth; i++)
            {
                for (int j = 0; j < grid_width; j++) grid[i, j] = ' ';
            }

            //x at flightpositions
            IAirspaceArea aa = _airspace.GetAirspaceArea();
            //float width = aa.NorthEastCornerX - aa.SouthWestCornerX;
            //float heigth = aa.NorthEastCornerY - aa.SouthWestCornerY;
            float width = aa.Width();
            float heigth = aa.Heigth();
            if (dps.Count > 0)
            {
                foreach (var dp in dps)
                {
                    int x = (int)lerp(0, grid_width, ((dp.X - aa.GetSouthWestCorner().X) / width));
                    int y = (int)lerp(0, grid_heigth, ((dp.Y - aa.GetSouthWestCorner().Y) / heigth));
                    grid[grid_heigth - 1 - y, x] = 'X';
                }
            }

            //grid to string + add border
            string line = ""; 
            for (int i = 0; i < grid_width; i++) line += "-";
            line = "+" + line + "+\n";
            airspacegrid += line;

            for (int i = 0; i < grid_heigth; i++)
            {
                airspacegrid += "|";
                for (int j = 0; j < grid_width; j++) airspacegrid += grid[i, j];
                airspacegrid += "|\n";
            }

            airspacegrid += line;

            return airspacegrid;
        }

        private float lerp(float a, float b, float f)
        {
            return a + f * (b - a);
        }

        //Vector2 topr = new Vector2(aa.NorthEastCornerX, aa.NorthEastCornerY);
        //Vector2 topl = new Vector2(aa.SouthWestCornerX, aa.NorthEastCornerY);
        //Vector2 btmr = new Vector2(aa.NorthEastCornerX, aa.SouthWestCornerY);
        //Vector2 btml = new Vector2(aa.SouthWestCornerX, aa.SouthWestCornerY);
        //float w_chunk = (Vector2.Distance(topr, topl) / w);
        //float h_chunk = (Vector2.Distance(topr, btmr) / h);
        //private void ASD(object o, AirspaceContentEventArgs args)
        //{
        //    Debug.Log("Monitor: Handling TransponderDataReady Event");
        //    foreach (var f in args.UpdatedFlights)
        //    {
        //        FTDataPoint dp = f.GetNewestDataPoint();
        //        Console.WriteLine("Tag: " + dp.Tag + " Pos: " + dp.X + "," + dp.Y + " Altitude: " + dp.Altitude + " Time: " + dp.TimeStamp + " Velocity: " + f.GetCurrentVelocity());
        //    }
        //}
    }
}
