using System.ComponentModel.DataAnnotations;

namespace Warenwritschaftssystem_der_Segitztherme.Models
{
    public class Lager
    {
        public int LagerID { get; set; }

        [Required(ErrorMessage = "Bitte eine Beschreibung eingeben.")]
        public string Beschreibung { get; set; }

        public Lager()
        {
        }
    }
}
