using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HigherThanTests
    {
        [TestMethod]
        public void AIsHigher()
        {

            Assert.AreEqual(1, MathOperations.HigherThan(NumberConverter.IntToBits(232), NumberConverter.IntToBits(200)));
            Assert.AreEqual(1, MathOperations.HigherThan(NumberConverter.IntToBits(232), NumberConverter.IntToBits(231)));
            Assert.AreEqual(1, MathOperations.HigherThan(NumberConverter.IntToBits(2500), NumberConverter.IntToBits(2)));
            Assert.AreEqual(1, MathOperations.HigherThan(NumberConverter.IntToBits(2738514), NumberConverter.IntToBits(12458)));
            Assert.AreEqual(1, MathOperations.HigherThan(NumberConverter.IntToBits(3), NumberConverter.IntToBits(2)));
            
        }

        [TestMethod]
        public void BIsHigher()
        {
            Assert.AreEqual(-1, MathOperations.HigherThan(NumberConverter.IntToBits(200), NumberConverter.IntToBits(232)));
            Assert.AreEqual(-1, MathOperations.HigherThan(NumberConverter.IntToBits(231), NumberConverter.IntToBits(232)));
            Assert.AreEqual(-1, MathOperations.HigherThan(NumberConverter.IntToBits(2), NumberConverter.IntToBits(2500)));
            Assert.AreEqual(-1, MathOperations.HigherThan(NumberConverter.IntToBits(12458), NumberConverter.IntToBits(2738514)));
        }

        [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(0, MathOperations.HigherThan(NumberConverter.IntToBits(200), NumberConverter.IntToBits(200)));
            Assert.AreEqual(0, MathOperations.HigherThan(NumberConverter.IntToBits(231), NumberConverter.IntToBits(231)));
            Assert.AreEqual(0, MathOperations.HigherThan(NumberConverter.IntToBits(2500), NumberConverter.IntToBits(2500)));
            Assert.AreEqual(0, MathOperations.HigherThan(NumberConverter.IntToBits(12458), NumberConverter.IntToBits(12458)));
        }
    }
}
