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
        public static int debugdetail = 3; //1 = Only Important, 3 = Very Specific
        public static void Log(string s)
        {
            if (debug)
            {
                Log(s, 3);
            }
        }
        public static void Log(string s, int d)
        {
            if (debug && (d >= debugdetail))
            {
                Console.WriteLine(s);
            }

        }
        public void LogDataPoint(FTDataPoint dp)
        {
            Console.WriteLine(
                  "Data: " + dp.Tag
                + "   Position: " + dp.X + "," + dp.Y
                + "   Altitude: " + dp.Altitude
                + "   Time: " + dp.TimeStamp
                );
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
