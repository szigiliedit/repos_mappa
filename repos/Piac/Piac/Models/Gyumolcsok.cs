using System;
using System.Collections.Generic;

#nullable disable

namespace Piac.Models
{
    public partial class Gyumolcsok
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Ar { get; set; }
        public byte Minoseg { get; set; }
        public string KepUtvonala { get; set; }
    }
}
