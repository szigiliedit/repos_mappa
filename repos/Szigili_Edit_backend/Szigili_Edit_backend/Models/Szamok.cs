using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Szigili_Edit_backend.Models
{
    public partial class Szamok
    {
        public int Id { get; set; }
        public string Nev { get; set; } = null!;
        public int Versenyzoid { get; set; }

        [JsonIgnore]
        public virtual Versenyzok Versenyzo { get; set; } = null!;
    }
}
