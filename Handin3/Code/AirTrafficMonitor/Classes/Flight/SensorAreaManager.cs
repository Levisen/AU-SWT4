using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
namespace AirTrafficMonitor
{
    public class SensorAreaManager : IFlightTrackManager
    {
        private List<IFlightTrack> _flights;
        private IFlightTrackDataSource _dataSource;

        public event EventHandler<FlightTracksUpdatedEventArgs> FlightTracksUpdated;
        public SensorAreaManager(IFlightTrackDataSource datasource)
        {
            _dataSource = datasource;
            _dataSource.FlightTrackDataReady += OnFlightTrackDataReady;
            _flights = new List<IFlightTrack>();
        }

        private void OnFlightTrackDataReady(object o, FlightTrackDataEventArgs args)
        {
            Debug.Log("FlightManager: Handling FlightTrackDataReady event, recieved " + args.FTDataPoints.Count + " Datapoints");
            List<FTDataPoint> recievedDataPoints = args.FTDataPoints;
            List<IFlightTrack> updatedflights = new List<IFlightTrack>();

            foreach (var dp in args.FTDataPoints)
            {
                if (!_flights.Exists(x => x.GetTag() == dp.Tag))
                {
                    Debug.Log("New flight entered sensor range with tag '" + dp.Tag + "'");
                    _flights.Add(new Flight(dp));
                }

                //Debug.Log("FlightManager: Adding datapoint to flight with tag '" + dp.Tag + "'");
                IFlightTrack f = _flights.Find(x => x.GetTag() == dp.Tag);
                f.AddDataPoint(dp);

                updatedflights.Add(f);
            }

            Debug.Log("FlightManager: Invoking FlightTracksUpdated, sending list of " + updatedflights.Count + " updated flights");
            FlightTracksUpdated?.Invoke(this, new FlightTracksUpdatedEventArgs(updatedflights));
        }

        public IFlightTrackDataSource GetDataSource()
        {
            return _dataSource;
        }

        public List<IFlightTrack> GetFlights()
        {
            return _flights;
        }
    }
}
