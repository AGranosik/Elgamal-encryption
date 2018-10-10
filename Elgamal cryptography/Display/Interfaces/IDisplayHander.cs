using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography.Display.Interfaces
{
    public interface IDisplayHander
    {
        void MainMenu();
        void GenerateVariables();
        void Verify();
        void LoadFromFile();
        void SaveToFile();

    }
}
