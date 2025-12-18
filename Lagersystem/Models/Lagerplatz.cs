namespace Lagersystem.Models
{
    public class Lagerplatz
    {
        public int LagerPlatzID { get; set; }
        public string LagerPlatzName { get; set; }
        public int LagerID { get; set; }
        public int HUAnzahl { get; set; }
        public float MaxGewicht { get; set; }
        public string LagerBereich { get; set; }
        public string LagerTyp { get; set; }

        public Lagerplatz()
        {
        }
    }
}
