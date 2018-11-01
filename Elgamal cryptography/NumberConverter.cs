using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public static int BitsToInt(int[] bits)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = bits.Length - 1; i >= 0; i--)
                sb.Append(bits[i]).ToString();

            return Convert.ToInt32(sb.ToString(), 2);
        }

        public static BigInteger BitsArraystoString(int[] number)
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

        public static int[] BigInttoBytes(BigInteger number)
        {
            var tmp = number.ToByteArray();

            StringBuilder sb = new StringBuilder();

            for(int i =tmp.Length-1; i >= 0; i--)
            {

                if(i != tmp.Length - 1)
                {
                    var ttt = Convert.ToString(Convert.ToInt32(tmp[i]), 2);
                    var left = 8 - ttt.Length % 8;
                    if (left == 8)
                        left = 0;
                    int j = 0;
                    while (j < left)
                    {
                        j++;
                        sb.Append("0");

                    }
                    sb.Append(ttt);
                }
                else
                {
                    sb.Append(Convert.ToString(Convert.ToInt32(tmp[i]), 2));

                }

            }

            var bitsInString = sb.ToString();

            int[] bits = new int[bitsInString.Length];

            for(var i =0; i< bits.Length; i++)
            {
                bits[i] = (int)Char.GetNumericValue(bitsInString[i]);
            }
            Array.Reverse(bits);
            return bits;

            //return BitConverter.GetBytes(tmp).ToArray();
        }
    }
}
