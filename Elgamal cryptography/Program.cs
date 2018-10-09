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

            elgamal.GenerateNumbers();
            Console.WriteLine(elgamal.ToString());

            Console.ReadKey();
        }
    }
}
