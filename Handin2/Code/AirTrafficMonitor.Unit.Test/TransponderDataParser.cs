using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor;

namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class TransponderDataParser
    {
        private DataReader uut;
        private string _transponderData;
        private string _newTransponderData;
        private ITransponderReceiver transponderReceiver;
        private List<FTDataPoint> _fTDataPoints;
        private int _eventReceived;
        [SetUp]
        public void Setup()
        {
            _eventReceived = 0;
            transponderReceiver = Substitute.For<ITransponderReceiver>();
            uut = new DataReader(transponderReceiver);
            _transponderData = "UAR043;75823;25472;9000;20181004154857789";
            _newTransponderData = "KIP632;39245;13132;9000;20181004154857789";
        }
        [Test]
        public void DataReader_ParseTransponderDataString_CorrectTag()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).Tag, Is.EqualTo("UAR043"));
        }
        [Test]
        public void DataReader_ParseTransponderDataString_CorrectX()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).X, Is.EqualTo("75823"));
        }
        [Test]
        public void DataReader_ParseTransponderDataString_CorrectY()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).Y, Is.EqualTo("25472"));
        }
        [Test]
        public void DataReader_ParseTransponderDataString_CorrectAltitude()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).Y, Is.EqualTo("9000"));
        }
        [Test]
        public void DataReader_ParseTransponderDataString_CorrectYear()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).TimeStamp.Year, Is.EqualTo("2018"));
        }
        public void DataReader_ParseTransponderDataString_CorrectMonth()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).TimeStamp.Year, Is.EqualTo("10"));
        }
        public void DataReader_ParseTransponderDataString_CorrectDay()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).TimeStamp.Year, Is.EqualTo("04"));
        }
        public void DataReader_ParseTransponderDataString_CorrectHour()
        {
            Assert.That(uut.ParseTransponderDataString(_transponderData).TimeStamp.Year, Is.EqualTo("15"));
        }

        [Test]
        public void DataReader_test()
        {
            var transponderDataRawData = new List<string> { _transponderData };
            var args = new RawTransponderDataEventArgs(transponderDataRawData);
            transponderReceiver.TransponderDataReady += Raise.EventWith(args);
            string[] seperatedData = _transponderData.Split(';');
        }
        
    }
}
