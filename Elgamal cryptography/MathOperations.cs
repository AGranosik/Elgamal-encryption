using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Elgamal_cryptography
{
    public static class MathOperations
    {
        //b always smaller than a
        public static int[] BitsSubstraction(int[] a, int[] b)
        {
            var higher = HigherThan(a, b);
            if (higher == -1)
                return null;
            else if (higher == 0)
                return new int[a.Length-1]; // returns 0

            int length = a.Length > b.Length ? a.Length : b.Length;
            int[] result = new int[length];
            int[] bProperLenght = new int[length];
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
        public static int HigherThan(int[] a, int[] b)
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

        public static int[] PowModulo(int[] a, int[] b, int[] mod)
        {

            var aa = NumberConverter.BitsArraystoString(a);
            var bb = NumberConverter.BitsArraystoString(b);
            var modd = NumberConverter.BitsArraystoString(mod);

            var result = BigInteger.ModPow(aa, bb, modd);

            return NumberConverter.BigInttoBytes(result);
        }

        public static int[] BitsMultiplier(int[] a, int[] b)
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

            int[] res = new int[result.Count];

            for(int i =0; i < result.Count; i++)
            {
                res[i] = result[i];
            }

            return res;

        }

        public static int[] Modulo(int[] a, int[] mod)
        {
            int higher = HigherThan(a, mod);

            if (higher == 0)
                return new int[1];

            while (higher == 1)
            {
                a = BitsSubstraction(a, mod);
                higher = HigherThan(a, mod);

            }

            if (higher == 0)
                return new int[1];

            return a;
        }

        public static int[] GCD (int[] a, int[] b)
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

        public static int[] InversePow(int[] a, int[] n)
        {
            var aa = NumberConverter.BitsArraystoString(a);
            var nn = NumberConverter.BitsArraystoString(n);

            BigInteger i = nn, v = 0, d = 1;
            while (aa > 0)
            {
                BigInteger t = i / aa;
                BigInteger x = aa;
                aa = i%x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            //v %= n;
            v = v%nn;
            //if (v < 0) v = (v + n) % n;
            if (v < 0)
                v = (v + nn) % nn;



            return NumberConverter.BigInttoBytes(v);
        }

        public static int[] Divide (int[] a, int[] b)
        {
            BigInteger counter = 0;
            while(HigherThan(a,b) > -1){
                a = BitsSubstraction(a, b);
                counter++;
            }

            return NumberConverter.BigInttoBytes(counter);
        }

        public static int[] BitsAddition(int[] a, int[] b)
        {
            int[] newA, newB;
            if(a.Length > b.Length)
            {
                newA = a;
                newB = new int[a.Length];

                for (int i = 0; i < b.Length; i++)
                    newB[i] = b[i];
            }
            else if(a.Length < b.Length)
            {
                newB = b;
                newA = new int[b.Length];

                for (int i = 0; i < a.Length; i++)
                    newA[i] = a[i];
            }
            else
            {
                newA = a;
                newB = b;
            }
            int[] result = new int[newA.Length + 1];
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