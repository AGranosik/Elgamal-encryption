﻿using System;
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

        public byte[] GetP(int keyLenght)//public key
        {
            byte[] result = new byte[keyLenght];
            do
            {
                rand.NextBytes(result);
            } while (!IsPrime(result));




            return result;
        }

        public byte[] GetNumber(int keyLenght)//public key
        {
            byte[] result = new byte[keyLenght];

            rand.NextBytes(result);
            return result;
        }

        public byte[] GetRandomNumberSmallerThan(byte[] p)
        {
            byte[] tmp = new byte[p.Length];
            do
            {
                tmp = GetNumber(p.Length);
            } while (MathOperations.HigherThan(tmp, p) < -1);


            return tmp;
        }

        public byte[] GetCoprimeInteger(byte[] p)
        {
            byte[] tmp;
            do
            {
                tmp = ng.GetP(p.Length);

            } while (MathOperations.HigherThan(tmp, p) > -1);

            return tmp;

        }

        public static bool IsPrime(byte[] number)
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
