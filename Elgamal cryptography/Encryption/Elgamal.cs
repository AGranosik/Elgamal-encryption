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
        private int a, p, g, k, kprim, m;
        private UInt64 r, s, b;
        private NumberGenerator ng = new NumberGenerator();

        public void GeneratePublicKeys()
        {
            //p = ng.GetP();
            //a = ng.GetRandomNumberSmallerThan(p);
            //g = ng.GetRandomNumberSmallerThan(p);
            //b = MathOperations.PowModulo(g, NumberConverter.IntToBits(a), p);
            p = 467;
            a = 127;
            g = 2;
            b = MathOperations.PowModulo(g, NumberConverter.IntToBits(a), p);

        }

        public void GeneratePrivateKeys(int message)
        {
            //m = message;
            m = 100;
            //k = ng.GetCoprimeInteger(p - 1);
            k = 213;
            r = MathOperations.PowModulo(g, NumberConverter.IntToBits(k), p);
            kprim = MathOperations.InversePow(k, p-1);
            //s is wrong
            Int64 s = Int64.Parse(a.ToString()) * Int64.Parse(r.ToString());
            s = Int64.Parse(m.ToString()) - s;
            s = s * Int64.Parse(kprim.ToString());
            //modulo z ujemnych wartości
            s = s % Int64.Parse((p - 1).ToString());

            //s = UInt64.Parse(kprim.ToString()) * (UInt64.Parse(m.ToString()) - ar) % UInt64.Parse((p - 1).ToString());

            ElgamalDescryptor dec = new ElgamalDescryptor();

            //dec.IsCorrect(b, r, s, g, m, p);
        }

        public override string ToString()
        {
            return "p: " + p + " a: " + a + " g: " + g + " k:" + k + " r:" + r;
        }
    }
}
