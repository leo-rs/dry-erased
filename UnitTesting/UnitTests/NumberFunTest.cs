using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class NumberFunTest
    {
        int a, b, c;

        [TestMethod]
        public void TestAddition()
        {
            a = 1;
            b = 2;
            c = 3;
            Assert.AreEqual(true, NumberFun.ThirdGradeMath(a, b, c));
        }

        [TestMethod]
        public void TestDivision()
        {
            a = 2;
            b = 24;
            c = 12;
            Assert.AreEqual(true, NumberFun.ThirdGradeMath(a, b, c));

        }

        [TestMethod]
        public void TestCaseFalse()
        {
            a = 5;
            b = 3;
            c = 1;
            Assert.AreEqual(false, NumberFun.ThirdGradeMath(a, b, c));
        }

        [TestMethod]
        public void TestSubtraction()
        {
            a = 9;
            b = 16;
            c = 7;
            Assert.AreEqual(true, NumberFun.ThirdGradeMath(a, b, c));
        }

        [TestMethod]
        public void TestMultiplication()
        {
            a = 7;
            b = 2;
            c = 14;
            Assert.AreEqual(true, NumberFun.ThirdGradeMath(a, b, c));
        }

        [TestMethod]
        public void TestCaseFalse2()
        {
            a = 12;
            b = 4;
            c = 2;
            Assert.AreEqual(false, NumberFun.ThirdGradeMath(a, b, c));
        }

    }
}