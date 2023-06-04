using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Haromszog> haromszoglista = new List<Haromszog>();
            StreamReader sr = new StreamReader("haromszogek2.csv");
            while (!sr.EndOfStream)
            {
                Haromszog h = new Haromszog(sr.ReadLine());
                haromszoglista.Add(h);
            }
            sr.Close();
            //10.feladat
            Console.WriteLine("derékszögű háromszögek adatai:");
            foreach (var item in haromszoglista)
            {
                if (Derekszogu(item.A, item.B, item.C))
                {
                    Console.WriteLine("a:" + item.A + " b:" + item.B + " c:" + item.C);
                }
            }



            Console.ReadLine();
        }

        public static bool Derekszogu(int A, int B, int C)
        {
            if (A * A + B * B == C * C)
            {
                return true;
            }
            return false;
        }

    }
}
