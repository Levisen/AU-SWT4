using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Interfaces;
using System;
using System.Globalization;

namespace AirTrafficMonitor.Unit.Test
{


        //[Test]    [TestFixture]
    public class ITransponderDataBundleReaderTest
    {
        private readonly ITransponderStringConverter _uut;
        private ITransponderReceiver _transponderReceiver;
        private List<string> _transponderData = new List<string>();
        private List<FTDataPoint> _FTDataPoints = new List<FTDataPoint>();
        
        [SetUp]
        public void SetUp()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();

            _transponderData.Add("UAR043; 75823; 25472; 9000; 20181004154857789");
            DateTime _stamp = DateTime.ParseExact("20181004154857789", "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

            _FTDataPoints.Add(new FTDataPoint("UAR043", 75823, 25472, 9000, _stamp));
        }
        //public void ITransponderDataBundleReader_DecodeRawTransponderData_FTDATAPointsContains()
        //{
        //    var a = new RawTransponderDataEventArgs(_transponderData);
        //    List<FTDataPoint> t = _uut.DecodeRawTransponderData(a);
        //    CollectionAssert.AreEqual(_FTDataPoints,t);
        //}
            

    }
}
