using Elgamal_cryptography;
using Elgamal_cryptography.Display.Interfaces;
using Elgamal_cryptography.Encriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisplayHander
    {
        private Elgamal _elgamal = null;
        private ElgamalDecryptor _decryptor = null;

        public MainWindow()
        {
            InitializeComponent();
            if (_elgamal == null)
                _elgamal = new Elgamal();
            if (_decryptor == null)
                _decryptor = new ElgamalDecryptor();
        }

        public bool Decrypt()
        {
            throw new NotImplementedException();
        }

        public void GeneratePublicKeys()
        {
            throw new NotImplementedException();
        }

        public void LoadFromFile()
        {
            throw new NotImplementedException();
        }

        public void MainMenu()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile()
        {
            throw new NotImplementedException();
        }
    }
}
