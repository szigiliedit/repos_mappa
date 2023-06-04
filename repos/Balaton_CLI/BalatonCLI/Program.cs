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
        struct Telek
        {
            public int Adoszam;
            public string Utca;
            public string Hazszam;
            public char Adosav;
            public int Alapterulet;
        }

        static public int adosavA = 0;
        static public int adosavB = 0;
        static public int adosavC = 0;

        public static int ado(char Ado_sav, int Terulet)
        {
            int Negyzetmeter = 0;
            if (Ado_sav == 'A')
            {
                Negyzetmeter = adosavA;
            }
            if (Ado_sav == 'B')
            {
                Negyzetmeter = adosavB;
            }
            if (Ado_sav == 'C')
            {
                Negyzetmeter = adosavC;
            }
            int Fiz_Ado = Negyzetmeter * Terulet;
            if (Fiz_Ado < 10000)
            {
                Fiz_Ado = 0;
            }
            return Fiz_Ado;
        }

        static void Main(string[] args)
        {
            List<Telek> telekLista = new List<Telek>();
            string[] darabok;
            Telek adat = new Telek();
            StreamReader sr = new StreamReader("utca.txt");
            darabok = sr.ReadLine().Split(' ');
            adosavA = Convert.ToInt32(darabok[0]);
            adosavB = Convert.ToInt32(darabok[1]);
            adosavC = Convert.ToInt32(darabok[2]);
            while (!sr.EndOfStream)
            {
                darabok = sr.ReadLine().Split(' ');
                adat.Adoszam = Convert.ToInt32(darabok[0]);
                adat.Utca = darabok[1];
                adat.Hazszam = darabok[2];
                adat.Adosav = Convert.ToChar(darabok[3]);
                adat.Alapterulet = Convert.ToInt32(darabok[4]);
                telekLista.Add(adat);
            }

            sr.Close();

            Console.WriteLine($"2. feladat: A mintában {telekLista.Count} telek szerepel.");

            Console.Write($"3. feladat. Egy tulajdonos adószáma: ");
            int bekertAdoszam = Convert.ToInt32(Console.ReadLine());
            int db = 0;
            int osszA = 0;
            int osszB = 0;
            int osszC = 0;
            for (int i = 0; i < telekLista.Count; i++)
            {
                if (telekLista[i].Adoszam == bekertAdoszam)
                {
                    Console.WriteLine($"{telekLista[i].Utca} utca {telekLista[i].Hazszam}");
                    db++;
                }
                if (telekLista[i].Adosav == 'A')
                {
                    osszA += ado(telekLista[i].Adosav, telekLista[i].Alapterulet);
                }
                if (telekLista[i].Adosav == 'B')
                {
                    osszB += ado(telekLista[i].Adosav, telekLista[i].Alapterulet);
                }
                if (telekLista[i].Adosav == 'C')
                {
                    osszC += ado(telekLista[i].Adosav, telekLista[i].Alapterulet);
                }
            }
            if (db == 0)
            {
                Console.WriteLine("Nem szerepel az adatállományban.");
            }

            Console.WriteLine("5. feladat");
            Console.WriteLine($"A sávba {telekLista.Count(x => x.Adosav == 'A')} telek esik, az adó {osszA} Ft.");
            Console.WriteLine($"B sávba {telekLista.Count(x => x.Adosav == 'B')} telek esik, az adó {osszB} Ft.");
            Console.WriteLine($"C sávba {telekLista.Count(x => x.Adosav == 'C')} telek esik, az adó {osszC} Ft.");

            StreamWriter sw = new StreamWriter("fizetendo.txt");

            for (int j = 0; j < telekLista.Count; j++)
            {
                sw.WriteLine($"{telekLista[j].Adoszam} {telekLista[j].Utca} {telekLista[j].Hazszam} {telekLista[j].Adosav} {telekLista[j].Alapterulet} {ado(telekLista[j].Adosav, telekLista[j].Alapterulet)}");
            }
            sw.Close();

            Console.ReadLine();
        }
    }
}