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
            int[] x2 = GetX2(elgamal);

            int[] br = GetBR(elgamal);
            int[] rs = GetRS(elgamal);
            var x1 = GetX1(elgamal, br, rs);

            var result = MathOperations.HigherThan(x1, x2) == 0;

            return result;
        }

        public int[] GetX1(Elgamal elgamal, int[] br, int[] rs)
        {
            var tmp = NumberConverter.BitsArraystoString(br) * NumberConverter.BitsArraystoString(rs) % NumberConverter.BitsArraystoString(elgamal.P);

            return NumberConverter.BigInttoBytes(tmp);
        }

        public int[] GetX2(Elgamal elgamal)
        {
            return MathOperations.PowModulo(elgamal.G, elgamal.M, elgamal.P);
        }

        public int[] GetBR(Elgamal elgamal)
        {
            return MathOperations.PowModulo(elgamal.B, elgamal.R, elgamal.P); //b^r%p
        }

        public int[] GetRS(Elgamal elgamal)
        {
            return MathOperations.PowModulo(elgamal.R, elgamal.S, elgamal.P); //r^s%p
        }

    }
}
