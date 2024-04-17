using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WineSite.Core.Models.Wine
{
    public class WineDetailsSevicesModel:WineServicesModel
    {

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Страна на произход")]
        public string Country { get; set; } = null!;

        [Required]
        [Display(Name = "Производител")]
        public string Manufucturer { get; set; } = null!;

        [Required]
        [Display(Name = "Вносител")]
        public string Importer { get; set; } = null!;

        [Display(Name = "Реколта")]
        public int Harvest { get; set; }

        [Display(Name = "Съдържание на алкохол")]
        public int AlcoholContent { get; set; }

        [Display(Name = "Бутилка")]
        public int Bottle { get; set; }

        public string Type { get; set; } = null!;

    }
}
