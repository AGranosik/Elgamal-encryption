using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Elgamal_cryptography
{
    public class ElgamalDescryptor
    {
        public bool IsCorrect(UInt64 b, UInt64 r, UInt64 s, int g, int m, int p)
        {
            UInt64 x2 = MathOperations.PowModulo(g, NumberConverter.IntToBits(m), p);
            UInt64 br = MathOperations.PowModulo(b, NumberConverter.UInt64ToBits(r), p); //b^r
            UInt64 rs = MathOperations.PowModulo(r, NumberConverter.UInt64ToBits(s), p); //r^s
            UInt64 x1 = (br * rs) % UInt64.Parse(p.ToString());

            return x1.Equals(x2);
        }
    }
}
