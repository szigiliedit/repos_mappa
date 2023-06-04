using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    class Telek
    {
        public string Adoszam { get; set; }
        public string Utca { get; set; }
        public string Hazszam { get; set; }
        public char Adosav { get; set; }
        public int Alapterulet { get; set; }

        public Telek(string bejegyzes)
        {
            string[] adatok = bejegyzes.Split(' ');
            Adoszam = adatok[0];
            Utca = adatok[1];
            Hazszam = adatok[2];
            Adosav = adatok[3][0];
            int ez;
            Alapterulet = int.TryParse(adatok[4], out ez) ? ez : 0;
        }
        public int Ado(int[] savdij, int alsohatar)
        {
            int alap = savdij[Adosav - 65] * Alapterulet;
            return alap < alsohatar ? 0 : alap;
        }
    }

    public class Program
    {
        static List<Telek> telekLista = new List<Telek>();
        static int[] adosavAr = new int[3];

        static void Main()
        {
            Beolvas();

            Console.Write("2. feladat. ");
            Console.WriteLine($"A mintában {telekLista.Count} adat szerepel");

            Console.Write("3. feladat. ");
            Console.Write("Egy tulajdonos adószáma: ");
            string adoszam = Console.ReadLine();
            if (Keres(adoszam) == 0)
                Console.WriteLine("Nem szerepel az adatállományban.");

            Console.WriteLine("5. feladat. ");
            Savonkent();
            FajlbaIras();
            Console.ReadLine();
        }

        public static void Beolvas()
        {
            StreamReader sr = new StreamReader("utca.txt");
            string[] sor = sr.ReadLine().Split(' ');
            for (int i = 0; i < 3; i++)
            {
                adosavAr[i] = int.Parse(sor[i]);
            }
            while (!sr.EndOfStream)
            {
                telekLista.Add(new Telek(sr.ReadLine()));
            }
            sr.Close();
        }

        private static void FajlbaIras()
        {
            StreamWriter sw = new StreamWriter("fizetendo.txt");

            for (int j = 0; j < telekLista.Count; j++)
            {
                sw.WriteLine($"{telekLista[j].Adoszam} {telekLista[j].Utca} {telekLista[j].Hazszam} {telekLista[j].Adosav} {telekLista[j].Alapterulet} {Adok(telekLista[j].Adosav, telekLista[j].Alapterulet, adosavAr)}");
            }
            sw.Close();
        }

        private static void Savonkent()
        {
            int[] telekdb = new int[3];
            int[] osszado = new int[3];
            foreach (Telek telek in telekLista)
            {
                telekdb[telek.Adosav - (int)'A']++;
                osszado[telek.Adosav - (int)'A'] += Adok(telek.Adosav, telek.Alapterulet, adosavAr);
            }
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{(char)(i + 'A')} sávba {telekdb[i],3} telek esik, az adó {osszado[i],10:N0} Ft.");
        }

        public static int Adok(char Ado_sav, int Terulet, int [] adosavAr1) //4. feladat.
        {
            int Fiz_Ado = adosavAr1[Ado_sav - 65] * Terulet;

            return Fiz_Ado < 10000 ? 0 : Fiz_Ado;
        }

        public static int Keres(string adoszam)
        {
            int db = 0;
            foreach (Telek telek in telekLista)
                if (telek.Adoszam == adoszam)
                {
                    Console.WriteLine($"{telek.Utca} utca {telek.Hazszam}");
                    db++;
                }
            return db;
        }
    }
}
