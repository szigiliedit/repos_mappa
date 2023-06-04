using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace FelhasznaloKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for Felhasznalok.xaml
    /// </summary>
    public partial class Felhasznalok : Window
    {
        bool beolvasva = false;
        int ID=0;
        string Salt = "";
        string Hash = "";

        private string Ellenorzes()
        {
            return "";
        }
        private void MezokTorlese()
        {
            ID = 0;
            txb_FelhasznaloNev.Text = "";
            pwb_Password.Password = "";
            txb_TeljesNev.Text = "";
            txb_Email.Text = "";
            cmb_Jogosultsag.Text = "0";
            cmb_Aktiv.Text = "1";
        }
        private void AdatBeolvasas()
        {
            List<AutoPiacWPF.Models.Felhasznalo> list = new List<AutoPiacWPF.Models.Felhasznalo>();
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = Encoding.UTF8;
            string url = $"https://localhost:5001/Felhasznalo/{AutoPiacWPF.MainWindow.User[0]}";
            MezokTorlese();
            try
            {
                string result = client.DownloadString(url);
                list = JsonConvert.DeserializeObject<List<AutoPiacWPF.Models.Felhasznalo>>(result);
            }
            catch (Exception ex) { }
            Felhasznalok_adatai.ItemsSource = list;
            beolvasva = true;
        }
        public Felhasznalok()
        {
            InitializeComponent();
            if (!beolvasva)
            {
                AdatBeolvasas();
                List<int> JogLista = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                List<int> AktivLista = new List<int>() { 0, 1 };
                cmb_Jogosultsag.ItemsSource = JogLista;
                cmb_Aktiv.ItemsSource = AktivLista;
            }
        }

        private void Felhasznalok_adatai_Changed(object sender, RoutedEventArgs e)
        {
            try
            {
                AutoPiacWPF.Models.Felhasznalo felhasznalo = Felhasznalok_adatai.SelectedItems[0] as AutoPiacWPF.Models.Felhasznalo;
                ID = felhasznalo.Id;
                txb_FelhasznaloNev.Text = felhasznalo.FelhasznaloNeve;
                pwb_Password.Password = "";
                Salt = felhasznalo.Salt;
                Hash = felhasznalo.Hash;
                txb_TeljesNev.Text = felhasznalo.TeljesNev;
                txb_Email.Text =felhasznalo.Email;
                cmb_Jogosultsag.Text = felhasznalo.Jogusultsag.ToString();
                cmb_Aktiv.Text = felhasznalo.Aktiv.ToString();
            }
            catch (Exception ex)
            {
                MezokTorlese();
            }
        }

        private void btn_Tarolas_Click(object sender, RoutedEventArgs e)
        {
            string uzenet = Ellenorzes();
            if (uzenet=="")
            {
                AutoPiacWPF.Models.Felhasznalo felhasznalo = new AutoPiacWPF.Models.Felhasznalo();
                felhasznalo.FelhasznaloNeve = txb_FelhasznaloNev.Text;
                felhasznalo.TeljesNev = txb_TeljesNev.Text;
                felhasznalo.Salt = AutoPiacWPF.MainWindow.GenerateSalt();
                felhasznalo.Hash = AutoPiacWPF.MainWindow.CreateSHA256(AutoPiacWPF.MainWindow.CreateSHA256(pwb_Password.Password + felhasznalo.Salt));
                felhasznalo.Email = txb_Email.Text;
                felhasznalo.Jogusultsag = int.Parse(cmb_Jogosultsag.Text);
                felhasznalo.Aktiv = int.Parse(cmb_Aktiv.Text);
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Encoding = Encoding.UTF8;
                string url = $"https://localhost:5001/Felhasznalo/{AutoPiacWPF.MainWindow.User[0]}";
                try
                {
                    string result = client.UploadString(url, "POST", JsonConvert.SerializeObject(felhasznalo));
                    MessageBox.Show(result);
                    AdatBeolvasas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(uzenet);
            }
        }

        private void btn_Modositas_Click(object sender, RoutedEventArgs e)
        {
            string uzenet = Ellenorzes();
            if (uzenet == "")
            {
                if (ID != 0)
                {
                    AutoPiacWPF.Models.Felhasznalo felhasznalo = new AutoPiacWPF.Models.Felhasznalo();
                    felhasznalo.Id = ID;
                    felhasznalo.FelhasznaloNeve = txb_FelhasznaloNev.Text;
                    felhasznalo.TeljesNev = txb_TeljesNev.Text;
                    if (pwb_Password.Password != "")
                    {
                        felhasznalo.Salt = AutoPiacWPF.MainWindow.GenerateSalt();
                        felhasznalo.Hash = AutoPiacWPF.MainWindow.CreateSHA256(AutoPiacWPF.MainWindow.CreateSHA256(pwb_Password.Password + felhasznalo.Salt));
                    }
                    else
                    {
                        felhasznalo.Salt = Salt;
                        felhasznalo.Hash = Hash;
                    }
                    felhasznalo.Email = txb_Email.Text;
                    felhasznalo.Jogusultsag = int.Parse(cmb_Jogosultsag.Text);
                    felhasznalo.Aktiv = int.Parse(cmb_Aktiv.Text);
                    WebClient client = new WebClient();
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string url = $"https://localhost:5001/Felhasznalo/{AutoPiacWPF.MainWindow.User[0]}";
                    try
                    {
                        string result = client.UploadString(url, "PUT", JsonConvert.SerializeObject(felhasznalo));
                        MessageBox.Show(result);
                        AdatBeolvasas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(uzenet);
            }
        }

        private void btn_Torles_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Biztosan törli a(z) {txb_TeljesNev.Text} nevű felhasználót?",
                    "Felhasználó törlése",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AutoPiacWPF.Models.Felhasznalo felhasznalo = new AutoPiacWPF.Models.Felhasznalo();
                felhasznalo.Id = ID;
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Encoding = Encoding.UTF8;
                string url = $"https://localhost:5001/Felhasznalo/{AutoPiacWPF.MainWindow.User[0]}?id={ID}";
                try
                {
                    string result = client.UploadString(url, "DELETE", "");
                    MessageBox.Show(result);
                    AdatBeolvasas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
