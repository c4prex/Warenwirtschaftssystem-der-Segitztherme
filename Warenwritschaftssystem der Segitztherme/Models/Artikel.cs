using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
>>>>>>> origin/dev

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Artikel
    {
        public int ArtikelID { get; set; }

        [Required]
<<<<<<< HEAD
        [StringLength(200)]

        [Required]
        public string ArtikelName { get; set; }

        public string? ArtikelBeschreibung { get; set; }

        public float ArtikelGewicht { get; set; }
        public float ArtikelMaße { get; set; }

<<<<<<< HEAD
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
        // ✅ OPTIONALER FK
        public int? LagerID { get; set; }

        // Navigation
        [ValidateNever]
        public Lager? Lager { get; set; }
    }
}
