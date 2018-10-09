using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography
{
    public static class MathOperations
    {

        public static int PowModulo(int a, int b, int mod)
        {
            //convert b to bits
            int[] bits = Convert.ToString(b, 2)
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();

            List<int> values = new List<int>();
            int prevValue = a;

            if (bits[0] == 1)
                values.Add(a);

            for(var i =1; i < bits.Count(); i++)
            {
                prevValue = (prevValue * prevValue) % mod;
                if(bits[i] == 1)
                    values.Add(prevValue);
            }

            return values.Aggregate((x, y) => x*y) % mod;
        }
    }
}
