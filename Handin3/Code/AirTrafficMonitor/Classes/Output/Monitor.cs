using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;
using System.Timers;

namespace AirTrafficMonitor
{
    public class Monitor : IMonitor
    {
        Dictionary<string, string> Sections;

        public Monitor()
        {
            Sections = new Dictionary<string, string>();

            var timer = new System.Timers.Timer(250);
            timer.Elapsed += CheckDeactivate;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void CheckDeactivate(object sender, ElapsedEventArgs e) { Draw(); }

        public void UpdateDisplaySection(string sectionname, string content)
        {
            Sections[sectionname] = content;
            //Draw(); // Should probably redraw elsewhere
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("[-AIRSPACE-GRID-]");
            RenderSection("AirspaceGrid");
            Console.WriteLine("[-FLIGHTS-IN-AIRSPACE-]");
            RenderSection("AirspaceFlightList");
            Console.WriteLine("[-ENTER/EXIT-AIRSPACE-EVENTS-]");
            RenderSection("AirspaceEventList");
            Console.WriteLine("[-SEPERATION-EVENTS-]");
            RenderSection("SeperationEventList");
        }

        private void RenderSection(string name)
        {
            if (Sections.ContainsKey(name)) Console.Write(Sections[name]);
            else Console.WriteLine(" nothing to display yet");
        }
    }
}
