using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Mitarbeiter
    {
        [Key]
        public int MitarbeiterID { get; set; } 

        [Required(ErrorMessage = "Vorname ist ein Pflichtfeld")]
        [StringLength(100)]
        public string Vorname { get; set; } = string.Empty; // z.B. Frank

        [Required(ErrorMessage = "Nachname ist ein Pflichtfeld")]
        [StringLength(100)]
        public string Nachname { get; set; } = string.Empty; // z.B. Schulz

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Telefon { get; set; }

        public bool IstAktiv { get; set; } = true;

        public DateTime ErstelltAm { get; set; } = DateTime.Now;

        // Computed Property - wird NICHT in der Datenbank gespeichert
        [NotMapped]
        public string Anzeigename => $"{Nachname}{Vorname.Substring(0, Math.Min(2, Vorname.Length))}"; // SchulzFr
    }
}
