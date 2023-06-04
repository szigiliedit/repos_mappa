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
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StreamReader sr = new StreamReader("nevek.txt");
            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                ListBox1.Items.Add(sor);
            }
            sr.Close();


        }
    }
}
