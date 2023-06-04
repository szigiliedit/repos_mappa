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
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace Filekezelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            kiirmindent();
        }

        public void kiirmindent()
        {
            string path = Directory.GetCurrentDirectory();
            string[] konyvtarak = Directory.GetDirectories(path);
            string[] fajlok = Directory.GetFiles(path);
            List<string> lista = new List<string>();
            lista.Add("..");
            foreach (string k in konyvtarak)
            {
                //lista.Add("[M] " + k);
                string[] darabok = k.Split('\\');
                lista.Add("[M] " + darabok[darabok.Length - 1]);

            }
            foreach (string f in fajlok)
            {
                string[] darabok = f.Split('\\');
                lista.Add("[f] " + darabok[darabok.Length - 1]);
            }
            listBox1.ItemsSource = lista;
            //  listBox1.Items.Refresh();

        }

        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "..")
            {
                string path = Directory.GetCurrentDirectory();
                int utolsovisszaper = path.LastIndexOf('\\');
                string ujpath = path.Remove(utolsovisszaper, path.Length - utolsovisszaper);
                Directory.SetCurrentDirectory(ujpath);
                //richTextBox1.Text = "" + ujpath;
                kiirmindent();
            }
            else
            {
                string[] darabok = listBox1.SelectedItem.ToString().Split(' ');
                if (darabok[0] == "[M]")
                {
                    string path = Directory.GetCurrentDirectory();
                    string ujpath = path + "\\" + darabok[1];
                    //richTextBox1.Text = "" + ujpath;

                    Directory.SetCurrentDirectory(ujpath);
                    kiirmindent();
                }

                if (darabok[0] == "[f]")
                {
                    string path = Directory.GetCurrentDirectory();
                    string ujpath = path + "\\" + darabok[1];
                    //richTextBox1.Text = "" + ujpath;
                    StreamReader sr = new StreamReader(ujpath);
                    string fajlszoveg = "";
                    for (int i = 0; i < 50; i++)
                    {
                        fajlszoveg += sr.ReadLine();
                    }
                    sr.Close();
                    richTextBox1.Text = fajlszoveg;




                    //kiirmindent();
                }



            }

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
