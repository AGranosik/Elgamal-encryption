using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitsSubstractionTests
    {
        [TestMethod]
        public void Substract()
        {
            Assert.AreEqual(2, NumberConverter.BitsToInt(MathOperations.BitsSubstraction(NumberConverter.IntToBits(32), NumberConverter.IntToBits(30))));
            Assert.AreEqual(20, NumberConverter.BitsToInt(MathOperations.BitsSubstraction(NumberConverter.IntToBits(84), NumberConverter.IntToBits(64))));
            Assert.AreEqual(200, NumberConverter.BitsToInt(MathOperations.BitsSubstraction(NumberConverter.IntToBits(876), NumberConverter.IntToBits(676))));
            Assert.AreEqual(123, NumberConverter.BitsToInt(MathOperations.BitsSubstraction(NumberConverter.IntToBits(723), NumberConverter.IntToBits(600))));
            Assert.AreEqual(8756, NumberConverter.BitsToInt(MathOperations.BitsSubstraction(NumberConverter.IntToBits(100000), NumberConverter.IntToBits(91244))));
        }
    }
}
