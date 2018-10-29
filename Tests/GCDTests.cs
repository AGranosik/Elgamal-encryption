using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GCDTests
    {
        [TestMethod]
        public void GCD()
        {
            int[] tmp = { 1,1,1,0,0,1,0,1,1,1,1,0,1,0,0,1,0,0,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0 };
            Array.Reverse(tmp);
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(7), NumberConverter.IntToBits(5))));
            Assert.AreEqual(7, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(175), NumberConverter.IntToBits(7))));
            Assert.AreEqual(7, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(7), NumberConverter.IntToBits(175))));
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(1236589), NumberConverter.IntToBits(2567))));
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(6519413), NumberConverter.IntToBits(122))));
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(6519413), NumberConverter.IntToBits(12))));
            Assert.AreEqual(9, NumberConverter.BitsToInt(MathOperations.GCD(NumberConverter.IntToBits(123432534), NumberConverter.IntToBits(12123))));
        }
    }
}
