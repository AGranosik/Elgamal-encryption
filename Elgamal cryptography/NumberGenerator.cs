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
        private List<BigInteger> listOfPrimes = new List<BigInteger>();
        public NumberGenerator()
        {
            //singleton
            if (rand == null)
                rand = new Random();

            listOfPrimes.Add(6);
        }

        public byte[] GetP(int keyLenght)//public key
        {
            byte[] result = new byte[keyLenght];
            do
            {
                rand.NextBytes(result);
            } while (!IsPrime(result));




            return result;
        }

        public int[] GetNumber(int keyLenght)//public key
        {
            int[] result = new int[keyLenght];

            for (int i = 0; i < keyLenght; i++)
                result[i] = rand.Next() % 2;



            return result;
        }

        public byte[] GetRandomNumberSmallerThan(byte[] p)
        {
            byte[] tmp = new byte[p.Length];
            do
            {
                tmp = GetP(p.Length);
            } while (MathOperations.HigherThan(tmp, p) < -1);


            return tmp;
        }

        public int[] GetCoprimeInteger(int[] p)
        {
            int[] tmp = new int[p.Length];
            int[] one = { 1 };
            //do
            //{
            //    tmp
            //} while (MathOperations.HigherThan(MathOperations.GCD(tmp, p), one) == 0);

            return tmp;
        }

        public static bool IsPrime(byte[] number)
        {
            var num = NumberConverter.BitsArraystoString(number);

            if (num < 2)
            {
                return false;
            }

            if (num == 2)
            {
                return true;
            }

            if (num % 2 == 0)
            {
                return false;
            }

            var sqrtOfNumber = BigIntegerExtension.Sqrt(num);

            for (var index = 3; index <= sqrtOfNumber; index += 2) //skip even numbers 
            {
                if (num % index == 0)
                {
                    return false;
                }
            }

            return true;
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
