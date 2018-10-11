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
        public void GeneratePrivateKeys(string message)
        {
            var lenght = message.Length;
            UInt64 mess = UInt64.Parse(message, System.Globalization.NumberStyles.HexNumber);
            _elgamal.GeneratePrivateKeys(mess);
        }

        public void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void MainMenu()
        {
            Console.WriteLine("Generuj klucze publiczne");
            Console.ReadKey();
            GeneratePublicKeys();
            Console.WriteLine(_elgamal.ToString());
            Console.WriteLine("Press key to generate Message");
            Console.ReadKey();
            var message = MessageHandler.HashMessage(MessageHandler.GenerateMessage());
            Console.WriteLine("Hashed Message : " + message);
            Console.WriteLine("Generuj klucze prywatne : ");
            GeneratePrivateKeys(message);

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
