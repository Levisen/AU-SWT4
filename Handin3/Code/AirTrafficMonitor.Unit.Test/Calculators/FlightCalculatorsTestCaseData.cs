using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Unit.Test
{
    public class FlightCalculatorsTestCaseData
    {
        public static IEnumerable CourseTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 2000, 2111).Returns(0);
                yield return new TestCaseData(2000, 2000, 2001, 2111).Returns(0.21);
            }
        }

        public static IEnumerable VelocityTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 2000, 2000, 1, 342).Returns(0);
                yield return new TestCaseData(2000, 2000, 2000, 2100, 1, 0).Returns(100);
            }
        }
    }
}
