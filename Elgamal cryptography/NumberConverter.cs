﻿using System;
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

            Array.Reverse(bits);
            return bits;
        }
        public static int[] UInt64ToBits(UInt64 n)
        {
            if (n == 0)
            {
                return new int[2] { 0, 0 };
            }
            var val = (int)Math.Ceiling(Math.Log(n, 2));
            if (val == 0)
                val++;
            var arr = new int[val];
            for (int i = val - 1, j = 0; i >= 0 && j <= val; i--, j++)
            {
                if ((n & ((UInt64)1 << i)) != 0)
                    arr[j] = 1;
                else
                    arr[j] = 0;
            }

            Array.Reverse(arr);

            return arr;
        }
    }
}
