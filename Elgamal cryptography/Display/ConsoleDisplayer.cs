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
        private ElgamalDecryptor _decryptor;
        public ConsoleDisplayer(Elgamal elgamal, ElgamalDecryptor decryptor)
        {
            _elgamal = elgamal;
            _decryptor = decryptor;
        }

        public void GeneratePublicKeys()
        {
            _elgamal.GeneratePublicKeys();
        }
        public void GeneratePrivateKeys(int[] message)
        {
            _elgamal.GeneratePrivateKeys(message);
        }

        public void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void MainMenu()
        {
            Console.WriteLine("Generuj publiczne");
            GeneratePublicKeys();
            var message = MessageHandler.GenerateMessage();
            GeneratePrivateKeys(message);
            Console.WriteLine(_elgamal.ToString());
            Console.WriteLine("Deszyfruj : ");
            Console.ReadKey();
            string decryption = "Czy podpis jest prawdziwy ? \n";
            //decryption += Decrypt() ? "TAK" : "NIE";
            Console.WriteLine(decryption);
        }



        public void SaveToFile()
        {
            throw new NotImplementedException();
        }

        //public bool Decrypt()
        //{
        //    return _decryptor.IsCorrect(_elgamal.B, _elgamal.R, _elgamal.Ss, _elgamal.G, _elgamal.M, _elgamal.P);
        //}
    }
}
