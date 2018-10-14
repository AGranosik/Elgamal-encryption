using Elgamal_cryptography.Display;
using Elgamal_cryptography.Display.Interfaces;
using Elgamal_cryptography.Encriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgamal_cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            Elgamal elgamal = new Elgamal();
            IDisplayHander displayHander = new ConsoleDisplayer(elgamal);


            //displayHander.MainMenu();

            UInt64 a = UInt64.Parse("43");
            UInt64 b = UInt64.Parse("16");
            int p = 101;

            //b nie jest poprawnie przekonwertowane
            Console.WriteLine(MathOperations.PowModulo(a, NumberConverter.UInt64ToBits(b), p));

            Console.ReadKey();
        }
    }
}
