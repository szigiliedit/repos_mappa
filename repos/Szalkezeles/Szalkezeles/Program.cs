using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Szalkezeles
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.Write("Kérem, adja meg a nevét: ");
                string name = Console.ReadLine();
                Console.WriteLine("Add meg az öt számot, amire lottózik a program: ");
                int[] lottoszam = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{i + 1}. szám: ");
                    lottoszam[i] = int.Parse(Console.ReadLine());
                }
            Console.WriteLine($"Üdvözlöm, {name}! Az Ön lottószámai: \n");

                Thread lottoThread = new Thread(() =>
                {
                    int huzasokSzama = 0;
                    Random rnd = new Random();

                    while (true)
                    {
                        int[] huzottSzamok = new int[5];
                        for (int i = 0; i < 5; i++)
                        {
                            huzottSzamok[i] = rnd.Next(1, 91);
                        }

                        huzasokSzama++;
                        if (EllenorizTalalatot(huzottSzamok))
                        {
                            Console.WriteLine($"\nGratulálok, {name}! {huzasokSzama}. húzásra lett 5 találatod!");
                            break;
                        }
                    }
                });

                DateTime inditasIdeje = DateTime.Now;
                lottoThread.Start();

                while (lottoThread.IsAlive)
                {
                    Console.WriteLine("Sorsolás folyamatban...");
                    Thread.Sleep(1000);
                }

                DateTime befejezesIdeje = DateTime.Now;
                TimeSpan teljesIdo = befejezesIdeje - inditasIdeje;

                Console.WriteLine($"\nA sorsolás összesen {teljesIdo.TotalSeconds:0.##} másodpercig tartott.");
                Console.ReadLine();
            }

            static bool EllenorizTalalatot(int[] huzottSzamok)
            {
                // A valódi ellenőrzés itt történne, most csak mindig false-t adunk vissza, hogy a while ciklus tovább fusson.
                return false;
            }
        
    }
}
