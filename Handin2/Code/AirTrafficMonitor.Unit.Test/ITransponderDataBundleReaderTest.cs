using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;
using AirTrafficMonitor.Interfaces;

namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class ITransponderDataBundleReaderTest
    {
        private ITransponderDataBundleReader _uut;
        private ITransponderReceiver _transponderReceiver;
        private List<string> _transponderData;
        private List<FTDataPoint> _FTDataPoints;
        private List<string> _newTransponderData;
        
        [SetUp]
        public void SetUp()
        {
            _transponderReceiver = Substitute.For<ITransponderReceiver>();
            _transponderData.Add("UAR043;75823;25472;9000;20181004154857789");
            _newTransponderData.Add("KIP632; 39245; 13132; 9000; 20181004154857789");
            _uut = new DataReader(_transponderReceiver);
        }
        [Test]
        public void ITransponderDataBundleReader_DecodeRawTransponderData_FTDATAPointsContains()
        {
            //add raw data as list<string> raise event, tjek
            var args = new RawTransponderDataEventArgs(_transponderData);
            _transponderReceiver.TransponderDataReady += Raise.EventWith(args);
            Assert.That(args.TransponderData[0], Is.EqualTo(_transponderData));
        }
            

    }
}
