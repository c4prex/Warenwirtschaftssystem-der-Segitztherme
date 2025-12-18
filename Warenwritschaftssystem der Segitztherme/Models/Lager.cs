namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Lager
    {
        public int LagerID { get; set; }

        [Required(ErrorMessage = "Bitte eine Beschreibung eingeben.")]
        public string Beschreibung { get; set; }

        // Audit-Felder
        public int? ErstelltVon { get; set; }
        public DateTime? ErstelltAm { get; set; }

        public int? GeaendertVon { get; set; }
        public DateTime? GeaendertAm { get; set; }

        // Navigation Properties
        [ForeignKey("ErstelltVon")]
        public Mitarbeiter? ErstelltVonMitarbeiter { get; set; }

        [ForeignKey("GeaendertVon")]
        public Mitarbeiter? GeaendertVonMitarbeiter { get; set; }
        public ICollection<Artikel> Artikel { get; set; } = new List<Artikel>();

        public Lager()
        {
        }
    }
}
