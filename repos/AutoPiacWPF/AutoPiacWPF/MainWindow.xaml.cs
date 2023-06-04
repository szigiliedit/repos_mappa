using FelhasznaloKarbantarto.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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

namespace AutoPiacWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] User = new string[3] {"","","" };
        static int SaltLength = 64;
        public static string GenerateSalt()
        {
            Random random = new Random();
            string karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string salt = "";
            for (int i = 0; i < SaltLength; i++)
            {
                salt += karakterek[random.Next(karakterek.Length)];
            }
            return salt;
        }

        public static string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender,RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_Closing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            if (AutoPiacWPF.MainWindow.User[1] != "")
            {
                string result = "";
                WebClient client = new WebClient();
                string[] valasz = new string[3];
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Encoding = System.Text.Encoding.UTF8;
                try
                {
                    string url = $"https://localhost:5001/Logout/{AutoPiacWPF.MainWindow.User[0]}";
                    result = client.UploadString(url, "POST");

                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                MessageBox.Show($"{result}\nViszlát {AutoPiacWPF.MainWindow.User[1]}!");
            }
        }

        private void Felhasznalok_Karbantartasa(object sender, RoutedEventArgs e)
        {
            Felhasznalok felhasznalok = new Felhasznalok();
            felhasznalok.ShowDialog();
        }
    }
}
