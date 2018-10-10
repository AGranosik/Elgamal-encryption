using System;
using System.Collections.Generic;
using System.Linq;

namespace Elgamal_cryptography
{
    public static class MathOperations
    {

        public static UInt64 PowModulo(int a, int b, int mod)
        {
            //convert b to bits
            int[] bits = Convert.ToString(b, 2)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();

            List<UInt64> values = new List<UInt64>();
            UInt64 prevValue = UInt64.Parse(a.ToString());
            UInt64 mod64 = UInt64.Parse(mod.ToString());

            if (bits[0] == 1)
                values.Add(UInt64.Parse(a.ToString()));

            for(var i =1; i < bits.Count(); i++)
            {
                prevValue = (prevValue * prevValue) % mod64;
                if(bits[i] == 1)
                    values.Add(prevValue);
            }

            return values.Aggregate((x, y) => x*y) % mod64;
        }
    }
}