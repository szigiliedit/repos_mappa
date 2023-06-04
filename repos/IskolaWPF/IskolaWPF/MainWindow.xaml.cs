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

namespace IskolaWPF
{
    public partial class MainWindow : Window
    {
        List<Tanulo> TanuloLista = new ();

        public MainWindow()
        {
            InitializeComponent();

            TanuloLista = BeolvasTanuloLista();
            TanuloAdatTabla.ItemsSource = TanuloLista;
        }

        public List<Tanulo> BeolvasTanuloLista()
        {
            StreamReader reader = new("nevek.txt");
            List<Tanulo> TanuloLista = new();

            while (!reader.EndOfStream)
            {
                string sor = reader.ReadLine();
                TanuloLista.Add(new Tanulo(sor));
            }
            reader.Close();

            return TanuloLista;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            int index = TanuloAdatTabla.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }
            else
            {
                TanuloLista.RemoveAt(index);
                TanuloAdatTabla.Items.Refresh();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Tanulo> adatok = new();
                foreach (var item in TanuloAdatTabla.Items)
                {
                    adatok.Add((Tanulo)item);
                }

                using (StreamWriter sw = new StreamWriter("nevekNEW.txt"))
                {
                    foreach (var adat in adatok)
                    {
                        sw.WriteLine($"{adat.KezdesEve};{adat.Osztaly};{adat.TanuloNeve}");
                    }
                    sw.Close();
                }
                MessageBox.Show("Sikeres mentés.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }

}
