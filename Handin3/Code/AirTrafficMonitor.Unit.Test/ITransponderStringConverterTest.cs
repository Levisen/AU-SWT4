using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Interfaces;
using System.Globalization;


namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class ITransponderStringConverterTest
    {
        private ITransponderStringConverter _uut;
        private ITransponderReceiver _transponderReceiver;

        private string _input;
        private FTDataPoint _output;

        [SetUp]
        public void SetUp()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new DataConverter(_transponderReceiver);
            _input = "UAR043;75823;25472;9000;20181004154857789";
            _output = _uut.ConvertTransponderString(_input);
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectTag()
        {
            Assert.That(_output.Tag, Is.EqualTo("UAR043"));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectX()
        {
            Assert.That(_output.X, Is.EqualTo(75823));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectY()
        {
            Assert.That(_output.Y, Is.EqualTo(25472));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectAltitude()
        {
            Assert.That(_output.Altitude, Is.EqualTo(9000));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectYear()
        {
            Assert.That(_output.TimeStamp.Year, Is.EqualTo(2018));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMonth()
        {
            Assert.That(_output.TimeStamp.Month, Is.EqualTo(10));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectDay()
        {
            Assert.That(_output.TimeStamp.Day, Is.EqualTo(04));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectHour()
        {
            Assert.That(_output.TimeStamp.Hour, Is.EqualTo(15));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMinute()
        {
            Assert.That(_output.TimeStamp.Minute, Is.EqualTo(48));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectSecond()
        {
            Assert.That(_output.TimeStamp.Second, Is.EqualTo(57));
        }

        [Test]
        public void ITransponderDataParser_ParseTransponderDataString_CorrectMillisecond()
        {
            Assert.That(_output.TimeStamp.Millisecond, Is.EqualTo(789));
        }
    }
}