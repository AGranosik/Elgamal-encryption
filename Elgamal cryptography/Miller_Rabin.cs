using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Elgamal_cryptography
{

    public class Miller_Rabin
    {
        private static NumberGenerator ng = new NumberGenerator();
        private static BigInteger[] powerOf2 = {
1<<0,  1<<1,  1<<2,  1<<3,  1<<4,  1<<5,  1<<6,
1<<7,  1<<8,  1<<9,  1<<10, 1<<11, 1<<12, 1<<13,
1<<14, 1<<15, 1<<16, 1<<17, 1<<18, 1<<19, 1<<20,
1<<21, 1<<22, 1<<23, 1<<24, 1<<25, 1<<26, 1<<27,
1<<28, 1<<29, 1<<30 };

        /// <summary>
        /// calculates a^b mod m
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <param name="m">m</param>
        /// <returns>a^b mod m</returns>
        public static BigInteger power_modulo_fast(BigInteger a, BigInteger b, BigInteger m)
        {
            BigInteger i;
            BigInteger result = 1;
            BigInteger x = a % m;

            for (i = 1; i <= b; i <<= 1)
            {
                x %= m;
                if ((b & i) != 0)
                {
                    result *= x;
                    result %= m;
                }
                x *= x;
            }

            return result;
        }

        /// <summary>
        /// Miller-Rabin test
        /// </summary>
        /// <param name="n">number to check</param>
        /// <param name="k">number of checks</param>
        /// <returns>true - probably prime, false - not prime</returns>
        public static bool MillerRabin(BigInteger n, BigInteger k)
        {
            BigInteger s = 0;
            BigInteger s2 = 1;
            int r;
            BigInteger a, d, i, prime;
            Random rand = new Random();

            if (n < 4)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }

            // calculate s and d
            while ((s2 & (n - 1)) == 0)
            {
                s += 1;
                s2 <<= 1;
            }
            d = n / s2;

            // try k times
            for (i = 0; i < k; i++)
            {
                a = NumberConverter.BitsArraystoString(ng.GetNumber(128)) + 1;
                if (power_modulo_fast(a, d, n) != 1)
                {
                    prime = 0;
                    for (r = 0; r <= s - 1; r++)
                    {
                        if (power_modulo_fast(a, powerOf2[r] * d, n) == n - 1)
                        {
                            prime = 1;
                            break;
                        }
                    }
                    if (prime == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
