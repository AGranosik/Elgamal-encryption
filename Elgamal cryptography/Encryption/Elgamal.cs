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
        private UInt64 r, ss, b;
        private NumberGenerator ng = new NumberGenerator();

        public void GeneratePublicKeys()
        {
            p = ng.GetP();
            a = ng.GetRandomNumberSmallerThan(p);
            g = ng.GetCoprimeInteger(p - 1);
            b = MathOperations.PowModulo(g, NumberConverter.IntToBits(a), p);
            //p = 739;
            //a = 25;
            //g = 7;
            //b = MathOperations.PowModulo(g, NumberConverter.IntToBits(a), p);

        }

        public void GeneratePrivateKeys(int message)
        {
            m = message;
            //m = 100;
            k = ng.GetCoprimeInteger(p - 1);
            //k = 127;
            r = MathOperations.PowModulo(g, NumberConverter.IntToBits(k), p);
            kprim = MathOperations.InversePow(k, p-1);
            Int64 s = Int64.Parse(a.ToString()) * Int64.Parse(r.ToString());
            s = Int64.Parse(m.ToString()) - s;
            s = s * Int64.Parse(kprim.ToString());
            s = s % Int64.Parse((p - 1).ToString());

            if(s < 0)
            {
                s += (p - 1);
            }
            ss = UInt64.Parse(s.ToString());

            //s = UInt64.Parse(kprim.ToString()) * (UInt64.Parse(m.ToString()) - ar) % UInt64.Parse((p - 1).ToString());

            ElgamalDescryptor dec = new ElgamalDescryptor();

            Console.WriteLine( dec.IsCorrect(b, r, ss, g, m, p));
        }

        public override string ToString()
        {
            return "p: " + p + " b :" + b + " a: " + a + " g: " + g + " k:" + k + " r:" + r + " kprim : " + kprim + " s: " + ss + " m: " + m ;
        }
    }
}
