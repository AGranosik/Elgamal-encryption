﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography
{
    public static class MathOperations
    {

        public static UInt64 PowModulo(int a, int[] b, int mod)
        {
            UInt64 mod64 = UInt64.Parse(mod.ToString());

            a = a % mod;

            UInt64 result = 1;

            UInt64 x = UInt64.Parse(a.ToString());

            for (int i = 0; i < b.Count(); i++)
            {
                if (b[i] == 1)
                {
                    result = result * x;
                    result = result % mod64;
                }
                x = x * x;
                x = x % mod64;
            }

            return result;
        }

        public static UInt64 PowModulo(UInt64 a, int[] b, int mod)
        {

            UInt64 mod64 = UInt64.Parse(mod.ToString());

            a = a % mod64;

            UInt64 result = 1;

            UInt64 x = a;

            for(int i =0; i < b.Count(); i++)
            {
                if(b[i] == 1)
                {
                    result = result * x;
                    result = result % mod64;
                }
                x = x * x;
                x = x % mod64;
            }

            //List<UInt64> values = new List<UInt64>();
            //UInt64 mod64 = UInt64.Parse(mod.ToString());
            //UInt64 prevValue = a % mod64;


            //if (b[0] == 1)
            //    values.Add(prevValue);

            //for (var i = 1; i < b.Count(); i++)
            //{
            //    prevValue = prevValue * prevValue;
            //    prevValue = prevValue % mod64;
            //    if (b[i] == 1)
            //        values.Add(prevValue);
            //}

            //UInt64 result = 1;

            //foreach (var e in values)
            //    result *= e;

            //result = result % mod64;

            return result;
        }

        public static string BitsMultiplier(int[] a, int[] b)
        {
            List<List<int>> toSum = new List<List<int>>();

            List<int> tmp;

            int empty = 0;
            for(int i = b.Length-1; i >= 0; i--)
            {
                tmp = new List<int>();
                for (var z = 0; z < empty; z++)
                    tmp.Add(0);
                for (int j=a.Length-1; j >= 0; j--)
                {
                    tmp.Add(a[j] * b[i]);
                }


                empty++;

                toSum.Add(tmp);
            }


            List<int> result = new List<int>();

            //dodać oczyszczanie z zero potem
            for (int i = 0; i < 64; i++)
                result.Add(0);

            int super = 0;
            int ttmp = 0;
            int resultIndex = 0;
            foreach(var list in toSum)
            {
                super = 0;
                for(int i = 0; i < list.Count; i++)
                {
                    resultIndex = i;
                    ttmp = 0;
                    ttmp = list[i] + super + result[resultIndex];
                    if(ttmp == 3)
                    {
                        super = 1;
                        result[resultIndex] = 1;
                    }
                    else if(ttmp == 2)
                    {
                        super = 1;
                        result[resultIndex] = 0;

                    }
                    else if (ttmp == 1)
                    {
                        super = 0;
                        result[resultIndex] = 1;
                    }
                    else
                    {
                        super = 0;
                        result[resultIndex] = 0;
                    }

                }
                    do
                    {
                        resultIndex += 1;
                        ttmp = super + result[resultIndex];
                        if (ttmp == 2)
                        {
                            super = 1;
                            result[resultIndex] = 0;

                        }
                        else if (ttmp == 1)
                        {
                            super = 0;
                            result[resultIndex] = 1;
                        }
                        else
                        {
                            super = 0;
                            result[resultIndex] = 0;
                        }
                    } while (super == 1);
            }

            StringBuilder sc = new StringBuilder();

            for (int i = result.Count - 1; i >= 0; i--)
                sc.Append(result[i].ToString());

            return sc.ToString();

        }

        public static int InversePow(int a, int n)
        {
            //for(int i =0; i < mod; i++)
            //{
            //    if ((k * i) % mod == 1)
            //        return i;

            //}
            //return 0;

            int i = n, v = 0, d = 1;
            while (a > 0)
            {
                int t = i / a;
                int x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}