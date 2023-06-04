using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    internal class Program
    { 
        static List<telek> teleklista = new List<telek>();
        static adosav A;
        static adosav B;
        static adosav C;

        static void Main(string[] args)
        {   
            StreamReader sr = new StreamReader("utca.txt");

            string sor0 = sr.ReadLine();    

            A=new adosav(sor0);

            while (!sr.EndOfStream)
            {
                teleklista.Add(new telek(sr.ReadLine()));
            }

            sr.Close();

            Console.WriteLine($"2. feladat. A mintában {teleklista.Count} telek szerepel.");

            Console.ReadLine();
        }

        public static int ado(string ado_sav,int terulet)
        {
            if (ado_sav== "A")
            {
                return A.adosavA * terulet;
            } 
            if (ado_sav== "B")
            {
                return B.adosavB * terulet;
            }
            if (ado_sav=="C")
            {
                return C.adosavC * terulet;
            }
            return 0;
        }
    }
}
