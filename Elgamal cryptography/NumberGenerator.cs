using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography
{
    public class NumberGenerator
    {
        private static Random rand;

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

        public int[] GetNUmber(int keyLenght)//public key
        {
            int[] result = new int[keyLenght];

            for (int i = 0; i < keyLenght; i++)
                result[i] = rand.Next() % 2;



            return result;
        }

        public int[] GetRandomNumberSmallerThan(int[] p)
        {
            int[] tmp = new int[p.Length];
            do
            {
                tmp = GetP(1024);
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

        public static bool IsPrime(int[] number)
        {
            int[] one = { 1 };
            int[] two = { 0, 1 };
            int[] three = { 1, 1 };
            int[] six = { 0, 1, 1 };
            if (MathOperations.HigherThan(number, one) == 0) return false;
            if (MathOperations.HigherThan(number, two) == 0) return true;
            if (MathOperations.HigherThan(number, three) == 0) return true;
            if (NumberConverter.BitsToInt(MathOperations.Modulo(number, two)) == 0) return false;
            if (NumberConverter.BitsToInt(MathOperations.Modulo(number, three)) == 0) return false;

            int[] i = { 0, 0, 1 };
            while(MathOperations.HigherThan(MathOperations.BitsMultiplier(i, i), number) <=0)
            {
                if (NumberConverter.BitsToInt(MathOperations.Modulo(number, i)) == 0 || NumberConverter.BitsToInt(MathOperations.Modulo(number, MathOperations.BitsAddition(i, two))) == 0)
                    return false;
                i = MathOperations.BitsAddition(i, six);
            }

            return true;
        }
    }
}
