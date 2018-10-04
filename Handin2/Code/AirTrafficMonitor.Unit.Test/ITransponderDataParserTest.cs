﻿using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class ITransponderDataParserTest
    {
        private ITransponderDataParser _uut;
        private string _transponderData;
        private ITransponderReceiver _transponderReceiver;
        private List<FTDataPoint> _FTDataPoints;

        [SetUp]
        public void Setup()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new DataReader(_transponderReceiver);
            _transponderData = "UAR043;75823;25472;9000;20181004154857789";
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectTag()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).Tag, Is.EqualTo("UAR043"));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectX()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).X, Is.EqualTo(75823));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectY()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).Y, Is.EqualTo(25472));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectAltitude()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).Altitude, Is.EqualTo(9000));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectYear()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Year, Is.EqualTo(2018));
        }
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMonth()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Month, Is.EqualTo(10));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectDay()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Day, Is.EqualTo(04));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectHour()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Hour, Is.EqualTo(15));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMinute()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Minute, Is.EqualTo(48));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectSecond()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Second, Is.EqualTo(57));
        }
        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMillisecond()
        {
            Assert.That(_uut.ParseTransponderDataString(_transponderData).TimeStamp.Millisecond, Is.EqualTo(57));
        }
    }
}