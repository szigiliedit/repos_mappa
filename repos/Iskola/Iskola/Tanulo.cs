using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Tanulo
    {
        public int KezdesEve { get; set; }
        public string Osztaly { get; set; }
        public string TanuloNeve { get; set; }

        public Tanulo(string sor)
        {
            string[] darabok = sor.Split(';');
            KezdesEve = Convert.ToInt32(darabok[0]);
            Osztaly = darabok[1];
            TanuloNeve = darabok[2];
        }
    }
}
