using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography.Encriptions
{
    public class Elgamal
    {
        private int a, p, g, k, kprim;
        private UInt64 r, s;
        private NumberGenerator ng = new NumberGenerator();

        public void GeneratePublicKeys()
        {
            p = ng.GetP();
            a = ng.GetRandomNumberSmallerThan(p);
            g = ng.GetRandomNumberSmallerThan(p);
        }

        public void GeneratePrivateKeys(int message)
        {
            k = ng.GetCoprimeInteger(p - 1);
            r = MathOperations.PowModulo(g, NumberConverter.IntToBits(k), p);
            kprim = MathOperations.InversePow(k, p-1);
            s = UInt64.Parse(kprim.ToString()) * (UInt64.Parse(message.ToString()) - (UInt64.Parse(a.ToString()) * r)) % UInt64.Parse((p - 1).ToString());
        }

        public override string ToString()
        {
            return "p: " + p + " a: " + a + " g: " + g + " k:" + k + " r:" + r;
        }
    }
}
