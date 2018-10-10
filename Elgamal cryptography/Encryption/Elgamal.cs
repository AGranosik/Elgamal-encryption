using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography.Encriptions
{
    public class Elgamal
    {
        private int a, p, g, k,s;
        private UInt64 r;
        private NumberGenerator ng = new NumberGenerator();

        public void GenerateNumbers()
        {
            p = ng.GetP();
            a = ng.GetRandomNumberSmallerThan(p);
            g = ng.GetRandomNumberSmallerThan(p);
            k = ng.GetCoprimeInteger(p);
            //generate r properly
            r = MathOperations.PowModulo(g, k, p);
        }

        public override string ToString()
        {
            return "p: " + p + " a: " + a + " g: " + g + " k:" + k + " r:" + r;
        }
    }
}
