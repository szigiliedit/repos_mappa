using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace BalatonWPF
{
    using BalatonWPF_Telkek;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            // adatok betöltése a DataGrid-be a txt fájlból

            string[] sor = File.ReadAllLines("utca.txt");
            List<Telkek> telekLista = new List<Telkek>();
            for (int i = 1; i < sor.Length; i++)
            {
                string[] telek = sor[i].Split(' ');
                telekLista.Add(new Telkek{ Adoszam = telek[0], Utca = telek[1], Hazszam = telek[2], Kategoria = telek[3], Terulet = telek[4] });
            }
            foreach (var telek in telekLista)
            {
                AdatTabla.Items.Add(telek);
            }

            CBox.SelectedItem = "A";
            CBox.ItemsSource = new List<string> { "A", "B", "C" };


        }

        private void Modosit_Click(object sender, RoutedEventArgs e)
        {
            // az aktuális sor lekérése a DataGrid-ból
            var selectedRow = AdatTabla.SelectedItem as Telkek;


            // az új kategória beállítása a kiválasztott sorban
            selectedRow.Kategoria = CBox.SelectedItem.ToString();

            // a DataGrid újrarajzolása a frissített adatokkal
            AdatTabla.Items.Refresh();
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiolvasás az adattáblázatból
                List<Telkek> adatok = new List<Telkek>();
                foreach (var item in AdatTabla.Items)
                {
                    adatok.Add((Telkek)item);
                }

                // Fájlba írás
                using (StreamWriter writer = new StreamWriter("modositottadatok.txt"))
                {
                    foreach (var adat in adatok)
                    {
                        writer.WriteLine($"{adat.Adoszam} {adat.Utca} {adat.Hazszam} {adat.Kategoria} {adat.Terulet}");
                    }
                    writer.Close();
                }
                MessageBox.Show("A mentés sikeres.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}