using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography
{
    public static class MathOperations
    {
        //b always smaller than a
        public static byte[] BitsSubstraction(byte[] a, byte[] b)
        {
            var higher = HigherThan(a, b);
            if (higher == -1)
                return null;
            else if (higher == 0)
                return new byte[a.Length-1]; // returns 0

            int length = a.Length > b.Length ? a.Length : b.Length;
            byte[] result = new byte[length];
            byte[] bProperLenght = new byte[length];
                for(int i =0; i < b.Length; i++)
                {
                    bProperLenght[i] = b[i];
                }

            var index = 0;
            int super = 0;

            do
            {
                var tmpResult = a[index] - bProperLenght[index];

                if(super == 1)
                {
                    if(tmpResult == -1)
                    {
                        super = 1;
                        result[index] = 0;
                    }
                    else if(tmpResult == 0)
                    {
                        super = 1;
                        result[index] = 1;
                    }
                    else
                    {
                        super = 0;
                        result[index] = 0;
                    }
                }
                else
                {
                    if(tmpResult == -1)
                    {
                        super = 1;
                        result[index] = 1;
                    }
                    else if (tmpResult == 0)
                    {
                        super = 0;
                        result[index] = 0;
                    }
                    else
                    {
                        super = 0;
                        result[index] = 1;

                    }
                }
                index++;
            } while (index < a.Length);

            return result;

        }

        //1 - a is higher, 0 - equal, -1 b is higher
        public static int HigherThan(byte[] a, byte[] b)
        {
            int aLenght = a.Length;
            int bLenght = b.Length;

            if(aLenght > bLenght)
            {
                int tmp = aLenght-1;

                do
                {
                    if (a[tmp] == 1)
                        return 1;
                    tmp--;
                } while (tmp > bLenght-1);

                int index = b.Length - 1;
                do
                {
                    if (a[index] > b[index])
                        return 1;
                    else if (a[index] < b[index])
                        return -1;

                    index--;
                } while (index >= 0);

            }
            else if (bLenght > aLenght)
            {
                int tmp = bLenght - 1;

                do
                {
                    if (b[tmp] == 1)
                        return -1;
                    tmp--;
                } while (tmp > aLenght-1);

                int index = a.Length - 1;
                do
                {
                    if (a[index] > b[index])
                        return 1;
                    else if (a[index] < b[index])
                        return -1;

                    index--;
                } while (index >= 0);
            }
            else
            {
                int tmp = aLenght - 1;
                do
                {
                    if (a[tmp] > b[tmp])
                        return 1;
                    else if (a[tmp] < b[tmp])
                        return -1;

                    tmp--;
                } while (tmp >= 0);
            }

            return 0;
        }

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

        public static byte[] BitsMultiplier(byte[] a, byte[] b)
        {
            List<List<int>> toSum = new List<List<int>>();

            List<int> tmp;

            int empty = 0;
            for(int i = 0 ; i < b.Length; i++)
            {
                tmp = new List<int>();
                for (var z = 0; z < empty; z++)
                    tmp.Add(0);
                for (int j=0; j < a.Length; j++)
                {
                    tmp.Add(a[j] * b[i]);
                }


                empty++;

                toSum.Add(tmp);
            }


            List<int> result = new List<int>();

            //dodać oczyszczanie z zero potem
            //ZWIEKSZENIE ZAKRESU
            int lenght = 0;
            foreach (var list in toSum)
                if (list.Count() > lenght)
                    lenght = list.Count();

            lenght++;
            for (int i = 0; i < lenght; i++)
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
                    } while (super == 1 && resultIndex+1 < result.Count);
            }

            byte[] res = new byte[result.Count];

            for(int i =0; i < result.Count; i++)
            {
                res[i] = (byte)result[i];
            }

            return res;

        }

        public static byte[] Modulo(byte[] a, byte[] mod)
        {
            int higher = HigherThan(a, mod);

            if (higher == 0)
                return new byte[1];

            while (higher == 1)
            {
                a = BitsSubstraction(a, mod);
                higher = HigherThan(a, mod);

            }

            if (higher == 0)
                return new byte[1];

            return a;
        }

        public static byte[] GCD (byte[] a, byte[] b)
        {
            int higher = HigherThan(a, b);

            while(higher != 0)
            {
                if (higher == 1)
                    a = BitsSubstraction(a, b);
                else
                    b = BitsSubstraction(b, a);

                higher = HigherThan(a, b);
            }

            return a;
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

        public static byte[] BitsAddition(byte[] a, byte[] b)
        {
            byte[] newA, newB;
            if(a.Length > b.Length)
            {
                newA = a;
                newB = new byte[a.Length];

                for (int i = 0; i < b.Length; i++)
                    newB[i] = b[i];
            }
            else if(a.Length < b.Length)
            {
                newB = b;
                newA = new byte[b.Length];

                for (int i = 0; i < a.Length; i++)
                    newA[i] = a[i];
            }
            else
            {
                newA = a;
                newB = b;
            }
            byte[] result = new byte[newA.Length + 1];
            int super = 0;
            for(int i =0; i < newA.Length; i++)
            {
                int tmpRes = super + newA[i] + newB[i];

                if(tmpRes == 3)
                {
                    super = 1;
                    result[i] = 1;
                }
                else if(tmpRes == 0)
                {
                    super = 0;
                    result[i] = 0;
                }
                else if(tmpRes == 2)
                {
                    super = 1;
                    result[i] = 0;
                }
                else
                {
                    super = 0;
                    result[i] = 1;
                }
            }

            if (super == 1)
                result[result.Length - 1] = 1;

            return result;
        }
    }
}