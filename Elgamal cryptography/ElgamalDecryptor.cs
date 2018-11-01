using Elgamal_cryptography.Encriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Elgamal_cryptography
{
    public class ElgamalDecryptor
    {
        public bool IsCorrect(Elgamal elgamal)
        {
            int[] x2 = MathOperations.PowModulo(elgamal.G, elgamal.M, elgamal.P);

            int[] br = MathOperations.PowModulo(elgamal.B, elgamal.R, elgamal.P); //b^r%p
            int[] rs = MathOperations.PowModulo(elgamal.R, elgamal.S, elgamal.P); //r^s%p
            //int[] x1 = MathOperations.Modulo(MathOperations.BitsMultiplier(br, rs), elgamal.P);
            var tmp = NumberConverter.BitsArraystoString(br) * NumberConverter.BitsArraystoString(rs) % NumberConverter.BitsArraystoString(elgamal.P);
            var x1 = NumberConverter.BigInttoBytes(tmp);

            var result = x1.Equals(x2);

            return result;
        }

    }
}
