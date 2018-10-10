using Elgamal_cryptography.Display.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography.Display
{
    public class ConsoleDisplayer : IDisplayHander
    {
        public void GenerateVariables()
        {
            throw new NotImplementedException();
        }

        public void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void MainMenu()
        {
            Console.WriteLine("1) Generuj klucze");
            Console.ReadKey();
            GenerateVariables();
        }

        public void SaveToFile()
        {
            throw new NotImplementedException();
        }

        public void Verify()
        {
            throw new NotImplementedException();
        }
    }
}
