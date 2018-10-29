using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitsMultiplier
    {
        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(20, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(2), NumberConverter.IntToBits(10))));
            Assert.AreEqual(200, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(2), NumberConverter.IntToBits(100))));
            Assert.AreEqual(4914, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(63), NumberConverter.IntToBits(78))));
            Assert.AreEqual(978750, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(1250), NumberConverter.IntToBits(783))));
            Assert.AreEqual(1000000, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(1000), NumberConverter.IntToBits(1000))));
            Assert.AreEqual(473859433, NumberConverter.BitsToInt(MathOperations.BitsMultiplier(NumberConverter.IntToBits(5413), NumberConverter.IntToBits(87541))));
        }
    }
}
