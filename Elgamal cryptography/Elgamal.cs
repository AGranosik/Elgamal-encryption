using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography
{
    public class Elgamal
    {
        private int a, b, c, p, g;
        private NumberGenerator ng = new NumberGenerator();

        public void GenerateNumbers()
        {
            p = ng.GetP();
            a = ng.GetRandomNumberSmallerThan(p);
            g = ng.GetRandomNumberSmallerThan(p);
        }
    }
}
