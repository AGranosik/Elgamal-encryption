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

        public int GetP()//public key
        {
            //p is large prime number
            int p = rand.Next();

            while (!IsPrime(p))
                p = rand.Next(2500);

            return p;
            
        }

        public int GetRandomNumberSmallerThan(int p)
        {
            return rand.Next(1, p);
        }

        public int GetCoprimeInteger(int p)
        {
            int potentialCoprimeInteger, k;
            int b = p;

            do
            {
                potentialCoprimeInteger = rand.Next(2, b);
                p = b;
                k = potentialCoprimeInteger;
                while (potentialCoprimeInteger != p)
                {
                    if (potentialCoprimeInteger > p)
                        potentialCoprimeInteger -= p;
                    else
                        p -= potentialCoprimeInteger;
                }

            } while (potentialCoprimeInteger != 1);

            return k;
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
