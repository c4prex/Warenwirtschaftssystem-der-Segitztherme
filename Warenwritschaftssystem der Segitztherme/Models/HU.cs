using System.ComponentModel.DataAnnotations.Schema;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class HU
    {
        public int HuId { get; set; }
        public int ArtikelID { get; set; }
        public int LagerID { get; set; }
        public float GewichtHu { get; set; }
        public int AnzahlArtikel { get; set; }

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
        public HU()
        {
            
        }
    }
}
