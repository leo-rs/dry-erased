using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class RomansTest
    {
        private double miles;

        [TestMethod]
        public void TestRomansMile()
        {
            miles = 1.0;
            Assert.AreEqual(1088, Romans.RoamingRomans(miles));
        }

        public void TestRomansRandomPrecision()
        {
            miles = 20.267;
            Assert.AreEqual(22046, Romans.RoamingRomans(miles));
        }

        public void TestRomansDoublePrecision()
        {
            miles = 8.710;
            Assert.AreEqual(9474, Romans.RoamingRomans(miles));
        }

        public void TestRomansTriplePrecision()
        {
            miles = 8.711;
            Assert.AreEqual(9476, Romans.RoamingRomans(miles));
        }
    }
}