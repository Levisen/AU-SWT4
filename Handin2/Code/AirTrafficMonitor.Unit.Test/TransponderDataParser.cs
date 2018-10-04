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
        public void DataReader_()
        {
            var transponderDataRawData = new List<string> { _transponderData };
            var args = new RawTransponderDataEventArgs(transponderDataRawData);
            transponderReceiver.TransponderDataReady += Raise.EventWith(args);
            string[] seperatedData = _transponderData.Split(';');
            Assert.That(_):
        }
        
    }
}
