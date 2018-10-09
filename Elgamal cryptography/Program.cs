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
            NumberGenerator ng = new NumberGenerator();
            int i = MathOperations.PowModulo(88, 24, 9);

            Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
