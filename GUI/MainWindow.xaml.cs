using Elgamal_cryptography;
using Elgamal_cryptography.Display.Interfaces;
using Elgamal_cryptography.Encriptions;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainWindow : Window
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

        public void Decrypt(object sender, RoutedEventArgs e)
        {
           var result = _decryptor.IsCorrect(_elgamal.B, _elgamal.R, _elgamal.Ss, _elgamal.G, _elgamal.M, _elgamal.P);
            x1Text.Content = _decryptor.x1;
            x2Text.Content = _decryptor.x2;
            ValidField.Content = result ? "TAK" : "NIE";
        }

        public void GeneratePublicKeys(object sender, RoutedEventArgs e)
        {
            _elgamal.GeneratePublicKeys();
            _elgamal.GeneratePrivateKeys(MessageHandler.GenerateMessage());
            PText.Content = _elgamal.P.ToString();
            BText.Content = _elgamal.B.ToString();
            GText.Content = _elgamal.G.ToString();
            RText.Content = _elgamal.R.ToString();
            SText.Content = _elgamal.Ss.ToString();
            MessageField.Content = _elgamal.M.ToString();
        }

        public void LoadFromFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Multiselect = false;

            //if you want filter all files            
            openFileDialog.DefaultExt = ".txt"; // Default file extension 
            openFileDialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            openFileDialog.ShowDialog();

            try
            {
                using(StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    _elgamal.P = int.Parse(sr.ReadLine());
                    _elgamal.A = int.Parse(sr.ReadLine());
                    _elgamal.B = UInt64.Parse(sr.ReadLine());
                    _elgamal.G = int.Parse(sr.ReadLine());
                    _elgamal.R = UInt64.Parse(sr.ReadLine());
                    _elgamal.Ss = UInt64.Parse(sr.ReadLine());
                    _elgamal.M = int.Parse(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {

            }
            PText.Content = _elgamal.P.ToString();
            BText.Content = _elgamal.B.ToString();
            GText.Content = _elgamal.G.ToString();
            RText.Content = _elgamal.R.ToString();
            SText.Content = _elgamal.Ss.ToString();
            MessageField.Content = _elgamal.M.ToString();
        }
    }
}
