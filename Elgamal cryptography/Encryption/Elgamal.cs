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
        public byte[] A { get; set; }
        public byte[] P { get; set; }
        public byte[] G { get; set; }
        public int K { get; set; }
        public int Kprim { get; set; }
        public int M { get; set; }
        public UInt64 R { get; set; }
        public UInt64 Ss { get; set; }
        public byte[] B { get; set; }
        public NumberGenerator ng = new NumberGenerator();



        public void GeneratePublicKeys()
        {
            P = ng.GetP(128);
            A = ng.GetRandomNumberSmallerThan(P);
            G = ng.GetCoprimeInteger(P);
            B = MathOperations.PowModulo(G, A, P);

        }

        public void GeneratePrivateKeys(int message)
        {
            //M = message;
            //K = ng.GetCoprimeInteger(P - 1);
            //R = MathOperations.PowModulo(G, NumberConverter.IntToBits(K), P);
            //Kprim = MathOperations.InversePow(K, P-1);
            //Int64 s = Int64.Parse(A.ToString()) * Int64.Parse(R.ToString());
            //s = Int64.Parse(M.ToString()) - s;
            //s = s * Int64.Parse(Kprim.ToString());
            //s = s % Int64.Parse((P - 1).ToString());
            //if(s < 0)
            //{
            //    s += (P - 1);
            //}
            //Ss = UInt64.Parse(s.ToString());
            //ElgamalDecryptor dec = new ElgamalDecryptor();
        }

        public override string ToString()
        {
            return "p: " + P + " b :" + B + " a: " + A + " g: " + G + " k:" + K + " r:" + R + " kprim : " + Kprim + " s: " + Ss + " m: " + M ;
        }
    }
}
