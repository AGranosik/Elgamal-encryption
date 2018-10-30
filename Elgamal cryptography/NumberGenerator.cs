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

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number == 3) return true;
            if (number % 2 == 0) return false;
            if (number % 3 == 0) return false;

            int i = 5;

            while(i*i <= number)
            {
                if (number % i == 0 || number % (i+2) == 0)
                    return false;
                i += 6;
            }

            return true;
        }
    }
}
