using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    public interface IMonitor
    {
        void UpdateDisplaySection(string sectionname, string content);
        void Draw();
    }
}
