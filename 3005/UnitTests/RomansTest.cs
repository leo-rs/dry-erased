using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RomansTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            double miles = 1.0;
            Assert.AreEqual(1088, Romans.RoamingRomans(miles));

        }
    }
}