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
            }
        }