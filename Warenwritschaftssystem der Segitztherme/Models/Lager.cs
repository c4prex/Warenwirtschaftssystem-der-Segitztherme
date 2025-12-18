namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Lager
    {
        public int LagerID { get; set; }

        public string Beschreibung { get; set; }

        public ICollection<Artikel> Artikel { get; set; } = new List<Artikel>();

        public Lager()
        {
        }
    }
}
