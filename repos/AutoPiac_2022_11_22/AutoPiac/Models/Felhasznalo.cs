using System;
using System.Collections.Generic;

#nullable disable

namespace AutoPiac.Models
{
    public partial class Felhasznalo
    {
        public int Id { get; set; }
        public string FelhasznaloNeve { get; set; }
        public string TeljesNev { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public int Jogusultsag { get; set; }
        public int Aktiv { get; set; }
    }
}
