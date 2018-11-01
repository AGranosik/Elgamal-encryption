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
        public int[] M { get; set; }
        public int[] R { get; set; }
        public int[] B { get; set; }
        public int[] S { get; set; }
        public NumberGenerator ng = new NumberGenerator();



        public void GeneratePublicKeys()
        {
            P = ng.GetP(128);
            A = ng.GetRandomNumberSmallerThan(P);
            G = ng.GetCoprimeInteger(P);
            B = GenerateB();

        }

        public int[] GenerateB()
        {
            return MathOperations.PowModulo(G, A, P);
        }

        public void GeneratePrivateKeys(int[] message)
        {
            int[] one = { 1 };

            M = message;
            K = ng.GetCoprimeInteger(P);
            R = GenerateR();
            Kprim = GenerateKprim();
            S = ng.GetS(Kprim, M, A, R, MathOperations.BitsSubstraction(P, one));
            ElgamalDecryptor dec = new ElgamalDecryptor();
        }

        public int[] GenerateR()
        {
            return MathOperations.PowModulo(G, K, P);
        }

        public int[] GenerateKprim()
        {
            int[] one = { 1 };

            return MathOperations.InversePow(K, MathOperations.BitsSubstraction(P, one));
        }

        public override string ToString()
        {
            return "p: " + NumberConverter.BitsArraystoString(P).ToString() + " b :" + NumberConverter.BitsArraystoString(B).ToString() + " a: " + NumberConverter.BitsArraystoString(A).ToString() + " g: " + NumberConverter.BitsArraystoString(G).ToString() + " k:" + NumberConverter.BitsArraystoString(K).ToString() + " r:" + NumberConverter.BitsArraystoString(R).ToString() + " kprim : " + NumberConverter.BitsArraystoString(Kprim).ToString() + " s: " + NumberConverter.BitsArraystoString(S).ToString() + " m: " + NumberConverter.BitsArraystoString(M).ToString();
        }
    }
}
