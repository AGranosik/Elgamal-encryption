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
            int[] one = { 1 };

            P = ng.GetP(1024);
            A = ng.GetRandomNumberSmallerThan(MathOperations.BitsSubstraction(P, one));
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
            return "p: " + NumberConverter.BitsArraystoString(P).ToString() + System.Environment.NewLine + " b :" + NumberConverter.BitsArraystoString(B).ToString() + System.Environment.NewLine + " a: " + NumberConverter.BitsArraystoString(A).ToString() + System.Environment.NewLine + " g: " + NumberConverter.BitsArraystoString(G).ToString() + System.Environment.NewLine + " k:" + NumberConverter.BitsArraystoString(K).ToString() + System.Environment.NewLine + " r:" + NumberConverter.BitsArraystoString(R).ToString() + System.Environment.NewLine + " kprim : " + NumberConverter.BitsArraystoString(Kprim).ToString() + System.Environment.NewLine + " s: " + NumberConverter.BitsArraystoString(S).ToString() + System.Environment.NewLine + " m: " + NumberConverter.BitsArraystoString(M).ToString();
        }
    }
}
