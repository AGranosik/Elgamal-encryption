using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NumberConverterTests
    {
        [TestMethod]
        public void BitsArraystoStringeTests()
        {
            int[] tmp = { 1, 1, 1, 1, 0, 1, 1 };
            Array.Reverse(tmp);

            Assert.AreEqual("123", NumberConverter.BitsArraystoString(tmp).ToString());
        }

        [TestMethod]
        public void BigIntToBitsTest()
        {
            int[] tmp = { 0,1,0,1};
            var ss = NumberConverter.BigInttoBytes(new System.Numerics.BigInteger(10));
        }
    }
}
