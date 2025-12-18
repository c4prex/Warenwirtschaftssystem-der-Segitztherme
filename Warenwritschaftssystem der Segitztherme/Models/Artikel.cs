using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Artikel
    {
        public int ArtikelID { get; set; }

        [Required]
        [StringLength(200)]
        public string ArtikelName { get; set; }
        public string ArtikelBeschreibung { get; set; }
        public float ArtikelGewicht { get; set; }
        public float ArtikelMaße { get; set; }

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
        public Artikel()
        {
            
        }
    }
}
