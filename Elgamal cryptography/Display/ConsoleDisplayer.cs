using Elgamal_cryptography.Display.Interfaces;
using Elgamal_cryptography.Encriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography.Display
{
    public class ConsoleDisplayer : IDisplayHander
    {
        private Elgamal _elgamal; 
        public ConsoleDisplayer(Elgamal elgamal)
        {
            _elgamal = elgamal;
        }

        public void GeneratePublicKeys()
        {
            _elgamal.GeneratePublicKeys();
        }
        public void GeneratePrivateKeys(int message)
        {
            _elgamal.GeneratePrivateKeys(message);
        }

        public void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void MainMenu()
        {
            Console.WriteLine("Generuj klucze publiczne");
            GeneratePublicKeys();
            Console.WriteLine(_elgamal.ToString());
            Console.WriteLine("Press key to generate Message");
            var message = MessageHandler.GenerateMessage();
            Console.WriteLine("Message : " + message);
            Console.WriteLine("Generuj klucze prywatne : ");
            GeneratePrivateKeys(message);
            Console.WriteLine(_elgamal.ToString());
            
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
