﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AirTrafficMonitor;

namespace AirTrafficMonitor.Unit.Test
{
    [TestFixture]
    public class TestUnitTest
    {
        [Test]
        public void CheckTestReturnsTjek()
        {
            var uut = new TestClass();
            Assert.That(uut.testConnect == "tjek");
        }
    }
}
