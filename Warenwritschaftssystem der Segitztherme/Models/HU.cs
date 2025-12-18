using System.ComponentModel.DataAnnotations;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class HU
    {
        [Display(Name = "Handling Unit")]
        public int HuId { get; set; }
        public int? ArtikelID { get; set; }
        public int? LagerID { get; set; }

        [Display(Name = "Gewicht der HU (kg)")]
        public float GewichtHu { get; set; }

        [Display(Name = "Anzahl der Artikel")]
        public int AnzahlArtikel { get; set; }

        public HU()
        {
            
        }
    }
}
