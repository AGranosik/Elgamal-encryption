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


            //foreach (var e in NumberConverter.IntToBits(33))
            //    Console.Write(e.ToString());

            //Console.WriteLine(MathOperations.BitsMultiplier(NumberConverter.IntToBits(5), NumberConverter.IntToBits(3)));


            displayHander.MainMenu();

            Console.ReadKey();
        }
    }
}
