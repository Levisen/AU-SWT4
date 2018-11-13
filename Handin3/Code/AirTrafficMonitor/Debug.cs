using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AirTrafficMonitor
{
    class Debug
    {
        public static bool debug = true;
        public static void Log(string s)
        {
            if (debug)
            {
                Console.WriteLine(s);
            }
        }

    }
}
