using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit.Test.TestData
{
    public class AirspaceAreaTestData
    {
        public static IEnumerable IsInsideTestData
        {
            get
            {
                //int x cord, int y cord, int altitude
                //10000, 15000, 90000, 95000, 500, 20000
                yield return new TestCaseData(9999, 14999, 15000).Returns(false).SetName("AirspaceArea_IsInside_SouthWestOutside");
                yield return new TestCaseData(90001, 14999, 15000).Returns(false).SetName("AirspaceArea_IsInside_SouthEastOutside");
                yield return new TestCaseData(90001, 95001, 15000).Returns(false).SetName("AirspaceArea_IsInside_NorthEastOutside");
                yield return new TestCaseData(9999, 95001, 15000).Returns(false).SetName("AirspaceArea_IsInside_NorthWestOutside");
                yield return new TestCaseData(10001, 94999, 15000).Returns(true).SetName("AirspaceArea_IsInside_NorthWestInside");
                yield return new TestCaseData(89999, 94999, 15000).Returns(true).SetName("AirspaceArea_IsInside_NorthEastInside");
                yield return new TestCaseData(89999, 15001, 15000).Returns(true).SetName("AirspaceArea_IsInside_SouthEastInside");
                yield return new TestCaseData(10001, 15001, 15000).Returns(true).SetName("AirspaceArea_IsInside_SouthWestInside");
                yield return new TestCaseData(45000, 45000, 499).Returns(false).SetName("AirspaceArea_IsInside_BelowBoundaryLower");
                yield return new TestCaseData(45000, 45000, 501).Returns(true).SetName("AirspaceArea_IsInside_AboveBoundaryLower");
                yield return new TestCaseData(45000, 45000, 19999).Returns(true).SetName("AirspaceArea_IsInside_BelowBoundaryUpper");
                yield return new TestCaseData(45000, 45000, 20001).Returns(false).SetName("AirspaceArea_IsInside_AboveBoundaryUpper");

            }
        }
    }
}
