using Microsoft.Extensions.Primitives;
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
using System.Windows.Shapes;

namespace AutoPiacWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        int szamlalo = 3;
        public Login()
        {
            InitializeComponent();
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

        private string SaltRequest(string UserName)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding=System.Text.Encoding.UTF8;
            try
            {
                string url = $"https://localhost:5001/Login/SaltRequest/{UserName}";
                string result = client.UploadString(url, "POST");
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string[] UserLogin(string UserName,string tmpHash)
        {
            WebClient client = new WebClient();
            string[] valasz = new string[3];
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                string url = $"https://localhost:5001/Login?nev={UserName}&tmpHash={tmpHash}";
                string result = client.UploadString(url, "POST");
                valasz = JsonConvert.DeserializeObject<string[]>(result);
                return valasz;
            }
            catch (Exception ex)
            {
                valasz[0]=ex.Message;
                valasz[1] = "";
                valasz[2] = "-1";
                return valasz;
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string salt = SaltRequest(UserName.Text);
            MainWindow.User = UserLogin(UserName.Text, CreateSHA256(Password.Password + salt));
            if (szamlalo>0)
            {
                if (MainWindow.User[1]=="")
                {
                    szamlalo--;
                    MessageBox.Show($"Sikertelen bejelentkezés.\n{MainWindow.User[0]}");
                    UserName.Text = "";
                    Password.Password = "";
                    if (szamlalo==0)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserName.Text == "")
            {
                ImageBrush userNameTextImageBrush = new ImageBrush();
                userNameTextImageBrush.ImageSource = new BitmapImage(new Uri(@"Images\fn.jpg", UriKind.Relative));
                userNameTextImageBrush.AlignmentX = AlignmentX.Left;
                userNameTextImageBrush.AlignmentY = AlignmentY.Center;
                userNameTextImageBrush.Stretch = Stretch.None;
                UserName.Background = userNameTextImageBrush;
            }
            else
            {
                UserName.Background = null;
            }

        }

        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {
            if (Password.Password == "")
            {
                ImageBrush passwordTextImageBrush = new ImageBrush();
                passwordTextImageBrush.ImageSource = new BitmapImage(new Uri(@"Images\pw.jpg", UriKind.Relative));
                passwordTextImageBrush.AlignmentX = AlignmentX.Left;
                passwordTextImageBrush.AlignmentY = AlignmentY.Center;
                passwordTextImageBrush.Stretch = Stretch.None;
                Password.Background = passwordTextImageBrush;
            }
            else
            {
                Password.Background = null;
            }

        }
    }
}
