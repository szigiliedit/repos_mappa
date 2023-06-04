using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoPiacWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void MenuPopntokBekapcsolasa(MainWindow window)
        {
            if (AutoPiacWPF.MainWindow.User[2]=="9")
            {
                window.mit_FelhAdatKarb.IsEnabled = true;
            }
        }
        private void Login(object sender,StartupEventArgs e)
        {
            Login login=new Login();
            Application.Current.MainWindow = login;
            MainWindow window = new MainWindow();
            login.ShowDialog();
            if (AutoPiacWPF.MainWindow.User[1]=="")
            {
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show($"Sikeresen bejelentkezve: {AutoPiacWPF.MainWindow.User[1]}");
                MenuPopntokBekapcsolasa(window);
                window.Show();
            }
        }
    }
}
