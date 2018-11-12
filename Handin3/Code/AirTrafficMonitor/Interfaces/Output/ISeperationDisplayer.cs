using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Interfaces
{
    interface ISeperationDisplayer
    {
        void RenderActiveSeperations(Airspace airspace);
    }
}
