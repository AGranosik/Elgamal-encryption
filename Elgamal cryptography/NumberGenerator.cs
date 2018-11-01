using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography
{
    public class NumberGenerator
    {
        private static Random rand;
        private static NumberGenerator ng = new NumberGenerator();
        public NumberGenerator()
        {
            //singleton
            if (rand == null)
                rand = new Random();
        }

        public int[] GetP(int keyLenght)//public key
        {
            int[] result = new int[keyLenght];
            do
            {
                for (int i = 0; i < keyLenght; i++)
                    result[i] = rand.Next() % 2;

            } while (!IsPrime(result));




            return result;
        }

        public int[] GetS(int[] kprim, int[] message, int[] a, int[] r, int[] pMinusOne)
        {
            var ar = MathOperations.BitsMultiplier(a, r);
            var tmp = MathOperations.BitsSubstraction(message, ar);
            #region
            BigInteger kprims = NumberConverter.BitsArraystoString(kprim);
            var aa = NumberConverter.BitsArraystoString(a);
            var rr = NumberConverter.BitsArraystoString(r);
            var m = NumberConverter.BitsArraystoString(message);

            var arr = aa * rr;

            var s = m - arr;
            s = kprims * s;

            #endregion

            return NumberConverter.BigInttoBytes(s);
        }

        public int[] GetNumber(int keyLenght)//public key
        {
            int[] result = new int[keyLenght];

            for(int i =0; i < keyLenght; i++)
            {
                result[i] = rand.Next() % 2;
            }
            return result;
        }

        public int[] GetRandomNumberSmallerThan(int[] p)
        {
            int[] tmp = new int[p.Length];
            do
            {
                tmp = GetNumber(p.Length);
            } while (MathOperations.HigherThan(tmp, p) < -1);


            return tmp;
        }

        public int[] GetCoprimeInteger(int[] p)
        {
            int[] tmp;
            do
            {
                tmp = ng.GetP(p.Length);

            } while (MathOperations.HigherThan(tmp, p) > -1);

            return tmp;

        }

        public static bool IsPrime(int[] number)
        {
           return Miller_Rabin.MillerRabin(NumberConverter.BitsArraystoString(number), 700);


            //var num = NumberConverter.BitsArraystoString(number);

            //if (num < 2)
            //{
            //    return false;
            //}

            //if (num == 2)
            //{
            //    return true;
            //}

            //if (num % 2 == 0)
            //{
            //    return false;
            //}

            //var sqrtOfNumber = BigIntegerExtension.Sqrt(num);

            //for (BigInteger index = sqrtOfNumber; index >=3; index -= 2) //skip even numbers 
            //{
            //    if (num % index == 0)
            //    {
            //        return false;
            //    }
            //}

            //return true;
            //var num = NumberConverter.BitsArraystoString(number);
            //if (num == 1) return false;
            //if (num == 2) return true;
            //if (num == 3) return true;
            //if (num % 2 == 0) return false;
            //if (num % 3 == 0) return false;



            //BigInteger i = 6;
            //while (i * i < num)
            //{
            //    if (num % i == 0 || num % (i + 2) == 0)
            //        return false;
            //    i += 6;
            //}

            //return true;
        }
    }
}
