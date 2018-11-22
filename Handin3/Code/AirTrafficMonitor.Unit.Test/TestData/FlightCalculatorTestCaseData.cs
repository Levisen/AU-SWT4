using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Unit.Test.TestData
{
    public class FlightCalculatorsTestCaseData
    {
        public static IEnumerable CourseTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 2000, 2111).Returns(0);
                yield return new TestCaseData(2000, 2000, 4000, 4000).Returns(45);
            }
        }

        public static IEnumerable VelocityTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 2000, 2000, 0, 0).Returns(0);
                yield return new TestCaseData(2000, 2000, 4000, 4000, 30, 0).Returns(30);
                yield return new TestCaseData(2000, 2000, 4000, 4000, 56, 50).Returns(56.049999999999997d);
            }
        }
    }
}
