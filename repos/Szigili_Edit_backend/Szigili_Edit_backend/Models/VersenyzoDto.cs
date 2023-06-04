namespace Szigili_Edit_backend.Models
{
    public class VersenyzoDto
    {
        public int id { get; set; }

        public string nev { get; set; } = null!;

        public int orszagId { get; set; }

        public string nem { get; set; } = null!;
    }
}
