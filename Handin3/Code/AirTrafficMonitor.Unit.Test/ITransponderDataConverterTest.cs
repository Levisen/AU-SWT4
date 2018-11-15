﻿using System;
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
        private DataConverter _uut;
        private ITransponderReceiver _iTransponderReceiver;
        private string _testData = "ATR423;39045;12932;14000;20151006213456789";
        private readonly List<string> _listString;
        private List<FTDataPoint> _listFTDataPoints;
        private int _eventsReceived;


        [SetUp]
        public void SetUp()
        {
            //_iTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _iTransponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            _uut = new DataConverter(_iTransponderReceiver);
            _listFTDataPoints = new List<FTDataPoint>();


            var _listString = new List<string>();
            _listString.Add(_testData);

            _uut.FlightTrackDataReady += (o, args) => 
            {
                _listFTDataPoints = args.FTDataPoints;
                _eventsReceived++;

            };

        }
        [Test]
        public void Transponderdata_EventTest_NoEvent()
        {
            _eventsReceived = 0;
            //var args = new RawTransponderDataEventArgs(_listString);
            _iTransponderReceiver.TransponderDataReady += (sender, args) => _eventsReceived++;
            Assert.That(_eventsReceived == 0);
        }
        //[Test]
        //public void Transponderdata_EventTest_OneEvent()
        //{
        //    _eventsReceived = 0;
        //    //var args = new RawTransponderDataEventArgs(_listString);
        //    _iTransponderReceiver.TransponderDataReady += (sender, args) => 
        //    {
        //        if(args.TransponderData.)
        //    };
        //    Assert.That(_eventsReceived == 0);
        //}
    }
}
