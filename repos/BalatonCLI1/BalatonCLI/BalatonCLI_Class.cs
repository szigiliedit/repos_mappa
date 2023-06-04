using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class adosav
    {
        public int adosavA;
        public int adosavB;
        public int adosavC;

       
        public adosav(string sor0)
        {
            string[] darabok0 = sor0.Split(' ');
            adosavA= Convert.ToInt32(darabok0[0]);
            adosavB = Convert.ToInt32(darabok0[1]);
            adosavC = Convert.ToInt32(darabok0[2]);
        }
    }
    public class telek
    {
        public int adoszam;
        public string utcanev;
        public string hazszam;
        public char adosav;
        public int alapterulet;

        public telek(string sor)
        {
            string[] darabok = sor.Split(' ');
            this.adoszam = Convert.ToInt32(darabok[0]);
            this.utcanev = darabok[1];
            this.hazszam= darabok[2];
            this.adosav= Convert.ToChar(darabok[3]);
            this.alapterulet = Convert.ToInt32(darabok[4]);
        }
    }
}
