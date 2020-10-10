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

namespace Prb.LussenCoderen.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncodeSimple_Click(object sender, RoutedEventArgs e)
        {
            txtLower.Text = EncodeSimple(txtUpper.Text);
        }

        private void btnDecodeSimple_Click(object sender, RoutedEventArgs e)
        {
            txtUpper.Text = DecodSimple(txtLower.Text);
        }
        string EncodeSimple(string source)
        {
            string target = "";
            int length = source.Length;
            char character;
            byte number;

            for (int r = 0; r < length; r++)
            {
                character = char.Parse(source.Substring(r, 1));
                number = (byte)character;
                number += 128;
                target += (char)number;

            }
            return target;
        }
        string DecodSimple(string source)
        {
            string target = "";
            int length = source.Length;
            char character;
            byte number;

            for (int r = 0; r < length; r++)
            {
                character = char.Parse(source.Substring(r, 1));
                number = (byte)character;
                number -= 128;
                target += (char)number;

            }
            return target;
        }

        string secret = Guid.NewGuid().ToString();

        private void btnEncodeComplex_Click(object sender, RoutedEventArgs e)
        {
            txtLower.Text = EncodeComplex(txtUpper.Text, secret);
        }
        private void btnDecodeComplex_Click(object sender, RoutedEventArgs e)
        {
            txtUpper.Text = DecodeComplex(txtLower.Text, secret);
        }
        string EncodeComplex(string source, string key)
        {
            int length = key.Length;
            char character;
            byte displacement = 0;
            byte number;
            string target = "";
            for (int r = 0; r < length; r++)
            {
                character = char.Parse(key.Substring(r, 1));
                displacement += (byte)character;
            }

            length = source.Length;
            for (int r = length - 1; r >= 0; r--)
            {
                character = char.Parse(source.Substring(r, 1));
                number = (byte)character;
                number += displacement;
                target += (char)number;

            }
            return target;
        }

        string DecodeComplex(string source, string key)
        {
            int length = key.Length;
            char character;
            byte displacement = 0;
            byte number;
            string target = "";
            for (int r = 0; r < length; r++)
            {
                character = char.Parse(key.Substring(r, 1));
                displacement += (byte)character;
            }

            length = source.Length;
            for (int r = length - 1; r >= 0; r--)
            {
                character = char.Parse(source.Substring(r, 1));
                number = (byte)character;
                number -= displacement;
                target += (char)number;

            }
            return target;
        }
    }
}
