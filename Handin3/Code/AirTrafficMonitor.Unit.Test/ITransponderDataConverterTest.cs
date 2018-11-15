using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Interfaces;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Events;

namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class ITransponderDataConverterTest
    {
        private DataConverter _dataconverter;
        private ITransponderReceiver _uut;
        private string _testData = "ATR423;39045;12932;14000;20151006213456789";
        private int _eventsReceived;
        private FTDataPoint _FTDataPoint;

        [SetUp]
        public void SetUp()
        {
            _dataconverter = Substitute.For<DataConverter>();
            _uut = TransponderReceiverFactory.CreateTransponderDataReceiver();
            _FTDataPoint = _dataconverter.ConvertTransponderString(_testData);


        }
        [Test]
        public void Levi()
        {
            _eventsReceived = 0;
            _dataconverter.FlightTrackDataReady += (sender, args) => 
            {
                if (args.FTDataPoints.Count != 1) _eventsReceived++;
            };
        }

        //private DataConverter _uut;
        //private ITransponderReceiver _iTransponderReceiver;
        //private string _testData = "ATR423;39045;12932;14000;20151006213456789";
        //private List<FTDataPoint> _listFTDataPoints;
        //private int _eventsReceived;
        //private List<string> _listString;

        //public object A { get; private set; }

        //[SetUp]
        //public void SetUp()
        //{
        //    //_iTransponderReceiver = Substitute.For<ITransponderReceiver>();
        //    _iTransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
        //    _uut = new DataConverter(_iTransponderReceiver);
        //    _listFTDataPoints = new List<FTDataPoint>();


        //    _listString = new List<string>();
        //    _listString.Add(_testData);

        //    _uut.FlightTrackDataReady += (o, args) => 
        //    {
        //        _listFTDataPoints = args.FTDataPoints;
        //        _eventsReceived++;

        //    };

        //}
        //[Test]
        //public void Dataconverter_EventTest_NoEvent()
        //{
        //    _eventsReceived = 0;
        //    //var args = new RawTransponderDataEventArgs(_listString);
        //    _iTransponderReceiver.TransponderDataReady += (sender, args) => _eventsReceived++;
        //    Assert.That(_eventsReceived == 0);
        //}
        //[Test]
        //public void Dataconverter_EventTest_OneEvent()
        //{
        //    _eventsReceived = 0;
        //    var args2 = new RawTransponderDataEventArgs(_listString);
        //    _iTransponderReceiver.TransponderDataReady += (sender, args) => _eventsReceived++;
        //    _uut.FlightTrackDataReady += (sender, args) => 
        //    {
        //        if (args.FTDataPoints.First(item => item.Tag != "daw") == "ATR423") _eventsReceived++;
        //    };

        //    _uut.Tra


        //    Assert.That(_eventsReceived == 0);
        //}
        ////[Test]
        ////public void Dataconverter_EventTest_OneEvent()
        ////{
        ////    _eventsReceived = 0;
        ////    //var args = new RawTransponderDataEventArgs(_listString);
        ////    _iTransponderReceiver.TransponderDataReady += (sender, args) =>
        ////    {
        ////        if (args.TransponderData.)
        ////    };
        ////    _uut.FlightTrackDataReady();
        ////    Assert.That(_eventsReceived == 0);
        ////}
    }
}
