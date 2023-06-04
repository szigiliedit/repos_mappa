using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Iskola
{
    public class Program
    {
        static List<Tanulo> TanuloLista = new List<Tanulo>();

        static void Main()
        {            
            Beolvas();
            Console.WriteLine("3. Feladat");
            KiIr();
            Console.WriteLine(TanuloLista.Count);// A tanulók száma.
            Console.WriteLine("4. Feladat");
            Console.Write($"{TanuloLista[0].TanuloNeve} -> "); // A lista első tanulójának neve
            Console.WriteLine(createazonosito(TanuloLista[0])); // Az első tanuló azonosítója
            Console.Write($"{TanuloLista[TanuloLista.Count - 1].TanuloNeve} -> "); // A lista második tanulójának neve
            Console.WriteLine(createazonosito(TanuloLista[TanuloLista.Count-1])); // A második tanuló azonosítója
            FajlbaIras();

            Console.ReadLine();
        }
        // Adatok beolvasása fájlból
        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("nevek.txt");
            while (!sr.EndOfStream)
            {
                TanuloLista.Add(new Tanulo(sr.ReadLine()));
            }
            sr.Close();
        }

        // Írja ki a képernyőre, a tanulók adatait!
        public static void KiIr()
        {
            foreach (var item in TanuloLista)
            {
                Console.WriteLine(item.TanuloNeve);
                Console.WriteLine(item.KezdesEve);
                Console.WriteLine(item.Osztaly);
            }
        }

        // azonosító létrehozása
        public static string createazonosito(Tanulo t)
        {
            string azonosito = "";
            azonosito += (t.KezdesEve % 10).ToString();
            azonosito += (t.Osztaly);
            azonosito += (t.TanuloNeve.Substring(0,3).ToLower());
            azonosito += (t.TanuloNeve.Split(' ')[1].Substring(0, 3).ToLower());

            return azonosito;
        }
        private static void FajlbaIras()
        {
            //Írja ki az azonosítók txt-be az összes tanuló nevét és azonosítóját!
            StreamWriter sw = new StreamWriter("azonositok.txt");
            foreach (Tanulo t in TanuloLista)
            {
                string sor = t.TanuloNeve + "  " + createazonosito(t);
                sw.WriteLine(sor);
            }
            sw.Close();

        }
    }
}
