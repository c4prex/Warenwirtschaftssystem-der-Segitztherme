namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Artikel
    {
        public int ArtikelID { get; set; }
        public string ArtikelName { get; set; }
        public string ArtikelBeschreibung { get; set; }
        public float ArtikelGewicht { get; set; }
        public float ArtikelMaße { get; set; }

        public Artikel()
        {
            
        }
    }
}
