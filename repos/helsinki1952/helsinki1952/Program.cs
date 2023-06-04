using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    internal class Program
    {
        static List<Helyezes> Helyezesek = new List<Helyezes>();

        static void Main(string[] args)
        {           
            Beolvas();
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Magyar olimpikonok pontszerző helyezéseinek száma: {Helyezesek.Count}");
            Console.WriteLine("4. feladat:");
            Console.Write("Helyezés száma: ");
            int helyezes = Convert.ToInt32(Console.ReadLine());
            if (Keres(helyezes) == 0)
                Console.WriteLine("Nem szerepel az adatállományban.");
            Console.WriteLine($"Olimpiai pontok száma: {Keres(helyezes)}");
            Console.WriteLine($"Olimpiai összpontok száma torna sportágban: {Osszpont()}");
            FajlbaIras();
            Console.ReadLine();
        }
                
        static void Beolvas()
        {
            StreamReader sr = new StreamReader("helsinki.txt");

            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                Helyezes h = new Helyezes(Convert.ToInt32(sor[0]), Convert.ToInt32(sor[1]), sor[2], sor[3]);
                Helyezesek.Add(h);
            }
            sr.Close();
        }
                
        public static int Keres(int helyezes)
        {
            int pontszam = 0;
            foreach (Helyezes h in Helyezesek)
            
                if (h.Elert == helyezes)
                {
                    switch (h.Elert)
                    {
                        case 1: pontszam = 7; break;
                        case 2: pontszam = 5; break;
                        case 3: pontszam = 4; break;
                        case 4: pontszam = 3; break;
                        case 5: pontszam = 2; break;
                        case 6: pontszam = 1; break;
                    }

                }
            
            return pontszam;
        }

        public static int Osszpont()
        {
            int osszpont = 0;
            foreach (Helyezes h in Helyezesek)

                if (h.SportAg == "torna")
                {
                    switch (h.Elert)
                    {
                        case 1: osszpont += 7; break;
                        case 2: osszpont += 5; break;
                        case 3: osszpont += 4; break;
                        case 4: osszpont += 3; break;
                        case 5: osszpont += 2; break;
                        case 6: osszpont += 1; break;
                    }

                }

            return osszpont;
        }

        private static void FajlbaIras()
        {
            StreamWriter sw = new StreamWriter("foglalas.txt");
            int sportolok = 0;
            foreach (Helyezes h in Helyezesek)
            {
                sportolok += h.SportolokSzama;
            }
            sw.WriteLine($"{sportolok}");
            sw.Close();
        }
    }
}
