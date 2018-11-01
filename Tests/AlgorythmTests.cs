using System;
using Elgamal_cryptography;
using Elgamal_cryptography.Encriptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AlgorythmTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Elgamal elgamal = new Elgamal();
            NumberGenerator ng = new NumberGenerator();
            ElgamalDecryptor decryptor = new ElgamalDecryptor();
            int[] one = { 1 };

            elgamal.P = NumberConverter.IntToBits(547);
            elgamal.G = NumberConverter.IntToBits(9);
            elgamal.A = NumberConverter.IntToBits(23);
            elgamal.M = NumberConverter.IntToBits(100);
            elgamal.K = NumberConverter.IntToBits(125);

            elgamal.B = elgamal.GenerateB();

            Assert.AreEqual("81", NumberConverter.BitsArraystoString(elgamal.B).ToString());
            elgamal.Kprim = elgamal.GenerateKprim();
            Assert.AreEqual("83", NumberConverter.BitsArraystoString(elgamal.Kprim).ToString());
            elgamal.R = elgamal.GenerateR();
            Assert.AreEqual("304", NumberConverter.BitsArraystoString(elgamal.R).ToString());
            elgamal.S = ng.GetS(elgamal.Kprim, elgamal.M, elgamal.A, elgamal.R, MathOperations.BitsSubstraction(elgamal.P, one));
            Assert.AreEqual("172", NumberConverter.BitsArraystoString(elgamal.S).ToString());

            Assert.AreEqual("81", NumberConverter.BitsArraystoString(decryptor.GetX2(elgamal)).ToString());
            Assert.AreEqual("304", NumberConverter.BitsArraystoString(decryptor.GetBR(elgamal)).ToString());
            Assert.AreEqual("182", NumberConverter.BitsArraystoString(decryptor.GetRS(elgamal)).ToString());
            Assert.AreEqual("81", NumberConverter.BitsArraystoString(decryptor.GetX1(elgamal, decryptor.GetBR(elgamal), decryptor.GetRS(elgamal))).ToString());

            Assert.AreEqual(true, decryptor.IsCorrect(elgamal));

        }
    }
}
