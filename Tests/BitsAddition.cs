using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitsAddition
    {
        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(20, NumberConverter.BitsToInt(MathOperations.BitsAddition(NumberConverter.IntToBits(10), NumberConverter.IntToBits(10))));
            Assert.AreEqual(123, NumberConverter.BitsToInt(MathOperations.BitsAddition(NumberConverter.IntToBits(10), NumberConverter.IntToBits(113))));
            Assert.AreEqual(201234, NumberConverter.BitsToInt(MathOperations.BitsAddition(NumberConverter.IntToBits(1789), NumberConverter.IntToBits(199445))));
        }
    }
}
