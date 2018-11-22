using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
namespace AirTrafficMonitor
{
    public class FlightManager : IFlightTrackerMultiple
    {
        List<IFlightTrackerSingle> Flights;
        IFlightTrackDataSource DataSource;

        public event EventHandler<FlightTracksUpdatedEventArgs> FlightTracksUpdated;
        public FlightManager(IFlightTrackDataSource datasource)
        {
            DataSource = datasource;
            DataSource.FlightTrackDataReady += OnFlightTrackDataReady;
            Flights = new List<IFlightTrackerSingle>();
        }

        private void OnFlightTrackDataReady(object o, FlightTrackDataEventArgs args)
        {
            Debug.Log("FlightManager: Handling FlightTrackDataReady event, recieved " + args.FTDataPoints.Count + " Datapoints");
            List<FTDataPoint> recievedDataPoints = args.FTDataPoints;
            List<IFlightTrackerSingle> updatedflights = new List<IFlightTrackerSingle>();

            foreach (var dp in args.FTDataPoints)
            {
                if (!Flights.Exists(x => x.GetTag() == dp.Tag))
                {
                    Debug.Log("New flight entered sensor range with tag '" + dp.Tag + "'");
                    Flights.Add(new Flight(dp));
                }

                //Debug.Log("FlightManager: Adding datapoint to flight with tag '" + dp.Tag + "'");
                IFlightTrackerSingle f = Flights.Find(x => x.GetTag() == dp.Tag);
                f.AddDataPoint(dp);

                updatedflights.Add(f);
            }

            Debug.Log("FlightManager: Invoking FlightTracksUpdated, sending list of " + updatedflights.Count + " updated flights");
            FlightTracksUpdated?.Invoke(this, new FlightTracksUpdatedEventArgs(updatedflights));
        }

        public IFlightTrackDataSource GetDataSource()
        {
            return DataSource;
        }

        public ICollection<FTDataPoint> GetAllFlights()
        {
            throw new NotImplementedException();
        }
    }
}
