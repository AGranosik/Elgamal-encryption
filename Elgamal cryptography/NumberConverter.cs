using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography
{
    public static class NumberConverter
    {
        public static int[] IntToBits(int number)
        {
            int[] bits = Convert.ToString(number, 2)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();
            return bits;
        }
    }
}
