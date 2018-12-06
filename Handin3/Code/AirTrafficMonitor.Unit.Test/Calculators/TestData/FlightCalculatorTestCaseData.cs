using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Test.Unit.Calculators.TestData
{
    public class FlightCalculatorsTestCaseData
    {
        public static IEnumerable CourseTestCases
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111).Returns(359.484).SetName("North 1");
                yield return new TestCaseData(2000, 2000, 2000, 2111).Returns(0.000).SetName("North 2");
                yield return new TestCaseData(2000, 2000, 2001, 2111).Returns(0.516).SetName("North 3");
                yield return new TestCaseData(2000, 2000, 2050, 2050).Returns(45.000).SetName("Northeast 1");
                yield return new TestCaseData(2000, 2000, 2050, 2111).Returns(24.249).SetName("Northeast 2");
                yield return new TestCaseData(2000, 2000, 2101, 2001).Returns(89.433).SetName("East 1");
                yield return new TestCaseData(2000, 2000, 2111, 2000).Returns(90.000).SetName("East 2");
                yield return new TestCaseData(2000, 2000, 2101, 1999).Returns(90.567).SetName("East 3");
                yield return new TestCaseData(2000, 2000, 2050, 1950).Returns(135.00).SetName("Southeast 1");
                yield return new TestCaseData(2000, 2000, 2051, 1990).Returns(101.094).SetName("Southeast 2");
                yield return new TestCaseData(2000, 2000, 2002, 1899).Returns(178.866).SetName("South 1");
                yield return new TestCaseData(2000, 2000, 2000, 1877).Returns(180.000).SetName("South 2");
                yield return new TestCaseData(2000, 2000, 1997, 1899).Returns(181.701).SetName("South 3");
                yield return new TestCaseData(2000, 2000, 1951, 1951).Returns(225.000).SetName("Southwest 1");
                yield return new TestCaseData(2000, 2000, 1879, 1961).Returns(252.135).SetName("Southwest 2");
                yield return new TestCaseData(2000, 2000, 1824, 1993).Returns(267.722).SetName("West 1");
                yield return new TestCaseData(2000, 2000, 1844, 2000).Returns(270.000).SetName("West 2");
                yield return new TestCaseData(2000, 2000, 1924, 2004).Returns(273.013).SetName("West 3");
                yield return new TestCaseData(2000, 2000, 1925, 2075).Returns(315.000).SetName("Northwest 1");
                yield return new TestCaseData(2000, 2000, 1902, 2142).Returns(325.389).SetName("Northwest 2");
            }
        }

        public static IEnumerable VelocityTestCases_1s_0ms
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 1, 000).Returns(111.005).SetName("North 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 1, 000).Returns(111.000).SetName("North 2 (straight), 1 sec");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 1, 000).Returns(111.005).SetName("North 3, 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 1, 000).Returns(70.711).SetName("Northeast 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 1, 000).Returns(121.742).SetName("Northeast 2, 1 sec");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 1, 000).Returns(101.005).SetName("East 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 1, 000).Returns(111.000).SetName("East 2 (straight), 1 sec");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 1, 000).Returns(101.005).SetName("East 3, 1 sec");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 1, 000).Returns(70.711).SetName("Southeast 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 1, 000).Returns(51.971).SetName("Southeast 2, 1 sec");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 1, 000).Returns(101.020).SetName("South 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 1, 000).Returns(123.000).SetName("South 2 (straight), 1 sec");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 1, 000).Returns(101.045).SetName("South 3, 1 sec");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 1, 000).Returns(69.296).SetName("Southwest 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 1, 000).Returns(127.130).SetName("Southwest 2, 1 sec");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 1, 000).Returns(176.139).SetName("West 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 1, 000).Returns(156.000).SetName("West 2 (straight), 1 sec");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 1, 000).Returns(76.105).SetName("West 3, 1 sec");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 1, 000).Returns(106.066).SetName("Northwest 1, 1 sec");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 1, 000).Returns(172.534).SetName("Northwest 2, 1 sec");
            }
        }
        public static IEnumerable VelocityTestCases_0s_999ms
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 0, 999).Returns(111.116).SetName("North 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 0, 999).Returns(111.111).SetName("North 2 (straight), 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 0, 999).Returns(111.116).SetName("North 3, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 0, 999).Returns(70.781).SetName("Northeast 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 0, 999).Returns(121.863).SetName("Northeast 2, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 0, 999).Returns(101.106).SetName("East 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 0, 999).Returns(111.111).SetName("East 2 (straight), 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 0, 999).Returns(101.106).SetName("East 3, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 0, 999).Returns(70.781).SetName("Southeast 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 0, 999).Returns(52.023).SetName("Southeast 2, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 0, 999).Returns(101.121).SetName("South 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 0, 999).Returns(123.123).SetName("South 2 (straight), 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 0, 999).Returns(101.146).SetName("South 3, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 0, 999).Returns(69.366).SetName("Southwest 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 0, 999).Returns(127.257).SetName("Southwest 2, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 0, 999).Returns(176.315).SetName("West 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 0, 999).Returns(156.156).SetName("West 2 (straight), 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 0, 999).Returns(76.181).SetName("West 3, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 0, 999).Returns(106.172).SetName("Northwest 1, 0s 999ms");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 0, 999).Returns(172.707).SetName("Northwest 2, 0s 999ms");
            }
        }

        public static IEnumerable VelocityTestCases_1s_001ms
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 1, 001).Returns(110.894).SetName("North 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 1, 001).Returns(110.889).SetName("North 2 (straight), 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 1, 001).Returns(110.894).SetName("North 3, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 1, 001).Returns(70.640).SetName("Northeast 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 1, 001).Returns(121.620).SetName("Northeast 2, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 1, 001).Returns(100.904).SetName("East 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 1, 001).Returns(110.889).SetName("East 2 (straight), 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 1, 001).Returns(100.904).SetName("East 3, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 1, 001).Returns(70.640).SetName("Southeast 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 1, 001).Returns(51.919).SetName("Southeast 2, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 1, 001).Returns(100.919).SetName("South 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 1, 001).Returns(122.877).SetName("South 2 (straight), 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 1, 001).Returns(100.944).SetName("South 3, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 1, 001).Returns(69.227).SetName("Southwest 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 1, 001).Returns(127.003).SetName("Southwest 2, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 1, 001).Returns(175.963).SetName("West 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 1, 001).Returns(155.844).SetName("West 2 (straight), 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 1, 001).Returns(76.029).SetName("West 3, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 1, 001).Returns(105.960).SetName("Northwest 1, 1s 001ms");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 1, 001).Returns(172.362).SetName("Northwest 2, 1s 001ms");
            }
        }

        public static IEnumerable VelocityTestCases_1s_378ms
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 1, 378).Returns(80.555).SetName("North 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 1, 378).Returns(80.552).SetName("North 2 (straight), 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 1, 378).Returns(80.555).SetName("North 3, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 1, 378).Returns(51.314).SetName("Northeast 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 1, 378).Returns(88.347).SetName("Northeast 2, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 1, 378).Returns(73.298).SetName("East 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 1, 378).Returns(80.552).SetName("East 2 (straight), 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 1, 378).Returns(73.298).SetName("East 3, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 1, 378).Returns(51.314).SetName("Southeast 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 1, 378).Returns(37.715).SetName("Southeast 2, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 1, 378).Returns(73.309).SetName("South 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 1, 378).Returns(89.260).SetName("South 2 (straight), 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 1, 378).Returns(73.327).SetName("South 3, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 1, 378).Returns(50.288).SetName("Southwest 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 1, 378).Returns(92.257).SetName("Southwest 2, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 1, 378).Returns(127.822).SetName("West 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 1, 378).Returns(113.208).SetName("West 2 (straight), 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 1, 378).Returns(55.229).SetName("West 3, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 1, 378).Returns(76.971).SetName("Northwest 1, 1s 378ms");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 1, 378).Returns(125.206).SetName("Northwest 2, 1s 378ms");
            }
        }

        public static IEnumerable VelocityTestCases_0s_579ms
        {
            get
            {
                yield return new TestCaseData(2000, 2000, 1999, 2111, 0, 579).Returns(191.718).SetName("North 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2000, 2111, 0, 579).Returns(191.710).SetName("North 2 (straight), 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2001, 2111, 0, 579).Returns(191.718).SetName("North 3, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2050, 2050, 0, 579).Returns(122.126).SetName("Northeast 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2050, 2111, 0, 579).Returns(210.262).SetName("Northeast 2, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2101, 2001, 0, 579).Returns(174.447).SetName("East 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2111, 2000, 0, 579).Returns(191.710).SetName("East 2 (straight), 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2101, 1999, 0, 579).Returns(174.447).SetName("East 3, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2050, 1950, 0, 579).Returns(122.126).SetName("Southeast 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2051, 1990, 0, 579).Returns(89.760).SetName("Southeast 2, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2002, 1899, 0, 579).Returns(174.473).SetName("South 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 2000, 1877, 0, 579).Returns(212.435).SetName("South 2 (straight), 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1997, 1899, 0, 579).Returns(174.516).SetName("South 3, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1951, 1951, 0, 579).Returns(119.683).SetName("Southwest 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1879, 1961, 0, 579).Returns(219.568).SetName("Southwest 2, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1824, 1993, 0, 579).Returns(304.213).SetName("West 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1844, 2000, 0, 579).Returns(269.430).SetName("West 2 (straight), 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1924, 2004, 0, 579).Returns(131.442).SetName("West 3, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1925, 2075, 0, 579).Returns(183.188).SetName("Northwest 1, 0s 579ms");
                yield return new TestCaseData(2000, 2000, 1902, 2142, 0, 579).Returns(297.986).SetName("Northwest 2, 0s 579ms");
            }
        }
    }
}
