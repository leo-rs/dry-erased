using UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RomansTest
    {
        double miles;

        [TestMethod]
        public void RomansTestOneMile()
        {
            miles = 1.0;
            Assert.AreEqual(1088, Romans.RoamingRomans(miles));
        }

        [TestMethod]
        public void RomansTestRandom()
        {
            miles = 20.267;
            Assert.AreEqual(22046, Romans.RoamingRomans(miles));
        }

        [TestMethod]
        public void RomansTestDoublePrecision()
        {
            miles = 8.710;
            Assert.AreEqual(9475, Romans.RoamingRomans(miles));
        }

        [TestMethod]
        public void RomansTestTriplePrecision()
        {
            miles = 8.711;
            Assert.AreEqual(9476, Romans.RoamingRomans(miles));
        }

    }
}