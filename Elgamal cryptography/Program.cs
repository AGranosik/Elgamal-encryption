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


            displayHander.MainMenu();

            Console.ReadKey();
        }
    }
}
