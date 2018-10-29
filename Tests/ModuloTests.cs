using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ModuloTests
    {
        [TestMethod]
        public void Modulo()
        {
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(7), NumberConverter.IntToBits(2))));
            Assert.AreEqual(2, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(200), NumberConverter.IntToBits(3))));
            Assert.AreEqual(1, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(742), NumberConverter.IntToBits(13))));
            Assert.AreEqual(4, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(789), NumberConverter.IntToBits(5))));
            Assert.AreEqual(172, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(7888896), NumberConverter.IntToBits(874))));
            Assert.AreEqual(21, NumberConverter.BitsToInt(MathOperations.Modulo(NumberConverter.IntToBits(4523106), NumberConverter.IntToBits(1743))));
        }
    }
}
