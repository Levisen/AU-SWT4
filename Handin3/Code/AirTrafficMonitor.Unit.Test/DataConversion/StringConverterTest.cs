using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TransponderReceiver;
using NSubstitute;
using AirTrafficMonitor.Interfaces;
using AirTrafficMonitor.Events;


namespace AirTrafficMonitor.Test.Unit
{
    class StringConverterTest
    {
        private ITransponderDataConverter _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new DataConverter(Substitute.For<ITransponderReceiver>());
        }


       
    }
}
