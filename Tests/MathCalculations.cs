using System;
using Elgamal_cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MathCalculations
    {
        [TestMethod]
        public void IsPrime()
        {
            int[] tmp = { 1,0,1,1,0,1,1,1,1,0,1,0,0,0,1,0,0,0,1,0,1,1,0,0,1,1,1,0,0,1,1,0,0,1 };
            Array.Reverse(tmp);
            Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(18)));
            Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(123)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(324239)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(324251)));
            Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(324250)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(tmp));
        }
        
        [TestMethod]
        public void InversePow()
        {
            Assert.AreEqual(3, NumberConverter.BitsToInt(MathOperations.InversePow(NumberConverter.IntToBits(10), NumberConverter.IntToBits(7))));
        }
    }
}
