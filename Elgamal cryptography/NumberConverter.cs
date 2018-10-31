using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Elgamal_cryptography
{
    public static class NumberConverter
    {
        public static byte[] IntToBits(int number)
        {
            int[] bits = Convert.ToString(number, 2)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();

            byte[] result = new byte[bits.Length];
            for (int i = 0; i < bits.Length; i++)
                result[i] = (byte)bits[i];

            Array.Reverse(result);
            return result;
        }
        public static int[] UInt64ToBits(UInt64 n)
        {
            if (n == 0)
            {
                return new int[2] { 0, 0 };
            }
            var log = Math.Log(n, 2);
            var val = (int)Math.Ceiling(log);

            if (log == val)
                val++;

            //if (val == 0)
            //    val++;
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

        public static int BitsToInt(byte[] bits)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = bits.Length - 1; i >= 0; i--)
                sb.Append(bits[i]).ToString();

            return Convert.ToInt32(sb.ToString(), 2);
        }

        public static BigInteger BitsArraystoString(byte[] number)
        {
            StringBuilder sb = new StringBuilder();

            for(int i =number.Length-1; i >= 0; i--)
            {
                sb.Append(number[i]);
            }

            BigInteger res = 0;
            var s = sb.ToString();            // I'm totally skipping error handling here
            foreach (char c in s)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            return res;
        } 

        public static byte[] BigInttoBytes(BigInteger number)
        {
            var tmp = number.ToByteArray();
            Array.Reverse(tmp);
            return tmp;
        }
    }
}
