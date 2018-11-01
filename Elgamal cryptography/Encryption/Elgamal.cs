using System;

namespace Elgamal_cryptography.Encriptions
{
    public class Elgamal
    {
        public int[] A { get; set; }
        public int[] P { get; set; }
        public int[] G { get; set; }
        public int[] K { get; set; }
        public int[] Kprim { get; set; }
        public int M { get; set; }
        public int[] R { get; set; }
        public UInt64 Ss { get; set; }
        public int[] B { get; set; }
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
            M = message;
            K = ng.GetCoprimeInteger(P);
            R = MathOperations.PowModulo(G, K, P);
            //Kprim = MathOperations.InversePow(K, P - 1);
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
