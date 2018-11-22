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
                yield return new TestCaseData(2000, 2000, 1999, 2111).Returns(359.4838358).SetDescription("North 1");
                yield return new TestCaseData(2000, 2000, 2000, 2111).Returns(0).SetDescription("North 2");
                yield return new TestCaseData(2000, 2000, 2001, 2111).Returns(0.5161642298).SetDescription("North 3");
                yield return new TestCaseData(2000, 2000, 2050, 2050).Returns(45).SetDescription("Northeast 1");
                yield return new TestCaseData(2000, 2000, 2050, 2111).Returns(24.24920441).SetDescription("Northeast 2");
                yield return new TestCaseData(2000, 2000, 2101, 2001).Returns(89.43273359).SetDescription("East 1");
                yield return new TestCaseData(2000, 2000, 2111, 2000).Returns(90).SetDescription("East 2");
                yield return new TestCaseData(2000, 2000, 2101, 1999).Returns(90.56726641).SetDescription("East 3");
                yield return new TestCaseData(2000, 2000, 2050, 1950).Returns(135).SetDescription("Southeast 1");
                yield return new TestCaseData(2000, 2000, 2051, 1990).Returns(101.093723).SetDescription("Southeast 2");
                yield return new TestCaseData(2000, 2000, 2002, 1899).Returns(178.8655784).SetDescription("South 1");
                yield return new TestCaseData(2000, 2000, 2000, 1877).Returns(180).SetDescription("South 2");
                yield return new TestCaseData(2000, 2000, 1997, 1899).Returns(181.7013546).SetDescription("South 3");
                yield return new TestCaseData(2000, 2000, 1951, 1951).Returns(225).SetDescription("Southwest 1");
                yield return new TestCaseData(2000, 2000, 1879, 1961).Returns(252.1351396).SetDescription("Southwest 2");
                yield return new TestCaseData(2000, 2000, 1824, 1993).Returns(267.722391).SetDescription("West 1");
                yield return new TestCaseData(2000, 2000, 1844, 2000).Returns(270).SetDescription("West 2");
                yield return new TestCaseData(2000, 2000, 1924, 2004).Returns(273.0127875).SetDescription("West 3");
                yield return new TestCaseData(2000, 2000, 1925, 2075).Returns(315).SetDescription("Northwest 1");
                yield return new TestCaseData(2000, 2000, 1902, 2142).Returns(325.3888578).SetDescription("Northwest 2");
            }
        }

        public static IEnumerable VelocityTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 1, 000).Returns(111.0045044).SetDescription("North 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 1, 000).Returns(111).SetDescription("North 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 1, 000).Returns(111.0045044).SetDescription("North 3 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 1, 000).Returns(70.71067812).SetDescription("Northeast 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 1, 000).Returns(121.7415295).SetDescription("Northeast 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 1, 000).Returns(101.0049504).SetDescription("East 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 1, 000).Returns(111).SetDescription("East 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 1, 000).Returns(101.0049504).SetDescription("East 3 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 1, 000).Returns(70.71067812).SetDescription("Southeast 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 1, 000).Returns(51.97114584).SetDescription("Southeast 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 1, 000).Returns(101.0198).SetDescription("South 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 1, 000).Returns(123).SetDescription("South 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 1, 000).Returns(101.0445446).SetDescription("South 3 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 1, 000).Returns(69.29646456).SetDescription("Southwest 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 1, 000).Returns(127.1298549).SetDescription("Southwest 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 1, 000).Returns(176.1391495).SetDescription("West 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 1, 000).Returns(156).SetDescription("West 2 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 1, 000).Returns(76.10519036).SetDescription("West 3 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 1, 000).Returns(106.0660172).SetDescription("Northwest 1 with 1 sec");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 1, 000).Returns(172.5340546).SetDescription("Northwest 2 with 1 sec");
            }
        }
        public static IEnumerable VelocityTestCases2
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 0, 999).Returns(111.11562).SetDescription("North 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 0, 999).Returns(111.1111111).SetDescription("North 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 0, 999).Returns(111.11562).SetDescription("North 3 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 0, 999).Returns(70.78145958).SetDescription("Northeast 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 0, 999).Returns(121.8633929).SetDescription("Northeast 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 0, 999).Returns(101.1060564).SetDescription("East 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 0, 999).Returns(111.1111111).SetDescription("East 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 0, 999).Returns(101.1060564).SetDescription("East 3 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 0, 999).Returns(70.78145958).SetDescription("Southeast 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 0, 999).Returns(52.02316901).SetDescription("Southeast 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 0, 999).Returns(101.120921).SetDescription("South 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 0, 999).Returns(123.1231231).SetDescription("South 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 0, 999).Returns(101.1456903).SetDescription("South 3 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 0, 999).Returns(69.36583039).SetDescription("Southwest 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 0, 999).Returns(127.257112).SetDescription("Southwest 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 0, 999).Returns(176.315465).SetDescription("West 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 0, 999).Returns(156.1561562).SetDescription("West 2 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 0, 999).Returns(76.18137173).SetDescription("West 3 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 0, 999).Returns(106.1721894).SetDescription("Northwest 1 with 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 0, 999).Returns(172.7067614).SetDescription("Northwest 2 with 0s 999ms");
            }
        }
    }
}
