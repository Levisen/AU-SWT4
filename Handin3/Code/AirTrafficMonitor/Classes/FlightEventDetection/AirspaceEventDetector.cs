using AirTrafficMonitor.Events;
using AirTrafficMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class AirspaceEventDetector : IAirspaceEventDetector
    {
        public event EventHandler<AirspaceEventDetectedArgs> AirspaceEventDetected;
        
        private IAirspace _datasource;
        private List<IFlightTrackerSingle> previous;

        public AirspaceEventDetector(IAirspace airspace)
        {
            previous = new List<IFlightTrackerSingle>();
            _datasource = airspace;
            _datasource.AirspaceContentUpdated += OnAirspaceContentUpdated;
        }

        private void OnAirspaceContentUpdated(object sender, AirspaceContentEventArgs e)
        {
            var newflights = e.AirspaceContent;
            
            if (newflights.Count > 0)
            {
                //var dps = new List<FTDataPoint>();
                //newflights.ForEach(f => dps.Add(f.GetNewestDataPoint()));

                foreach (var newf in newflights)
                {
                    if (!previous.Any(x => x.GetTag() == newf.GetTag()))
                    {
                        AirspaceEvent newevent = new AirspaceEvent(newf, true);
                        AirspaceEventDetected?.Invoke(this, new AirspaceEventDetectedArgs(newevent));
                    }
                }
                //foreach (var oldf in previous)
                //{
                //    if (!newflights.Any(x => x.GetTag() == oldf.GetTag()))
                //    {
                //        AirspaceEvent newevent = new AirspaceEvent(oldf, false);
                //        AirspaceEventDetected?.Invoke(this, new AirspaceEventDetectedArgs(newevent));
                //    }
                //} 
            }
            previous.Clear();
            previous.AddRange(newflights);
        }
    }
}
