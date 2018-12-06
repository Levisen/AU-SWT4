using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor
{
    public class AirspaceManager : IAirspaceManager, IFlightTrackManager
    {
        private IAirspaceArea _airspaceArea;
        private IFlightTrackManager _dataSource;
        private List<IFlightTrack> _content;

        public event EventHandler<AirspaceContentEventArgs> AirspaceContentUpdated;
        public event EventHandler<FlightTracksUpdatedEventArgs> FlightTracksUpdated;

        public AirspaceManager(IFlightTrackManager datasource, IAirspaceArea airspaceArea)
        {
            _airspaceArea = airspaceArea;
            _content = new List<IFlightTrack>();
            _dataSource = datasource;
            _dataSource.FlightTracksUpdated += OnFlightTracksUpdated;
        }

        private void OnFlightTracksUpdated(object o, FlightTracksUpdatedEventArgs args)
        {
            List<IFlightTrack> allUpdatedFlights = args.UpdatedFlights;

            _content.Clear();

            foreach (var f in allUpdatedFlights)
            {
                var pos = f.GetCurrentPosition();
                if (_airspaceArea.IsInside((int)pos.X, (int)pos.Y, (int)f.GetCurrentAltitude()))
                {
                    _content.Add(f);
                }
            }

            FlightTracksUpdated?.Invoke(this, new FlightTracksUpdatedEventArgs(_content));
            AirspaceContentUpdated?.Invoke(this, new AirspaceContentEventArgs(_content));
        }

        public List<IFlightTrack> GetAirspaceContent()
        {
            return _content;
        }

        public IFlightTrackManager GetDataSource()
        {
            return _dataSource;
        }

        public IAirspaceArea GetAirspaceArea()
        {
            return _airspaceArea;
        }

        public List<IFlightTrack> GetFlights()
        {
            return _content;
        }
    }
}
