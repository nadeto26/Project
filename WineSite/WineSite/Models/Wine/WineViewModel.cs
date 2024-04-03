using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static WineSite.Data.Constants.Wine;
using static WineSite.Data.Constants;

namespace WineSite.Models.Wine
{
    public class WineViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Вид")]
        public int TypeId { get; set; }

        [Required]
        [Display(Name = "Година на производство")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Снимка Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Страна на произход")]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [Display(Name = "Производител")]
        [StringLength(ManufucturerMaxLength, MinimumLength = ManufucturerMinLength)]
        public string Manufucturer { get; set; } = null!;

        [Required]
        [Display(Name = "Вносител")]
        [StringLength(ImporterMaxLength, MinimumLength = ImporterMinLength)]
        public string Importer { get; set; } = null!;


        [Display(Name = "Цена на бутилка")]
        [Range(0.00, MaxPricePerBottle, ErrorMessage = errorMessage)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Сорт")]
        [StringLength(SortMaxLength, MinimumLength = SortMinLength)]
        public string Sort { get; set; } = null!;

        [Display(Name = "Реколта")]
        public int Harvest { get; set; }

        [Display(Name = "Съдържание на алкохол")]
        public int AlcoholContent { get; set; }

        [Display(Name = "Бутилка")]
        public int Bottle { get; set; }
    }
}
