using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography.Display.Interfaces
{
    public interface IDisplayHander
    {
        void MainMenu();
        void GeneratePublicKeys();
        void LoadFromFile();
        void SaveToFile();
        bool Decrypt();
    }
}
