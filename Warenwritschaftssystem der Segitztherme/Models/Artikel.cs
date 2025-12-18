using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Artikel
    {
        public int ArtikelID { get; set; }

        [Required]
        public string ArtikelName { get; set; }

        public string? ArtikelBeschreibung { get; set; }

        public float ArtikelGewicht { get; set; }
        public float ArtikelMaße { get; set; }

        // ✅ OPTIONALER FK
        public int? LagerID { get; set; }

        // Navigation
        [ValidateNever]
        public Lager? Lager { get; set; }
    }
}
