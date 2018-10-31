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
            byte[] tmp = { 1,0,1,1,0,1,1,1,1,0,1,0,0,0,1,0,0,0,1,0,1,1,0,0,1,1,1,0,0,1,1,0,0,1 };
            Array.Reverse(tmp);
            //Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(3)));
            //Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(5)));
            //Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(7)));
            //Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(2)));
            //Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(18)));
            //Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(123)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(324239)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(NumberConverter.IntToBits(324251)));
            Assert.AreEqual(false, NumberGenerator.IsPrime(NumberConverter.IntToBits(324250)));
            Assert.AreEqual(true, NumberGenerator.IsPrime(tmp));
        }
    }
}
