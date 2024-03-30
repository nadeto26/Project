using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WineSite.Services.Wine.Models;

namespace WineSite.Models.Wine
{
    public class WineServicesModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Име")]
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
 
        [Display(Name = "Цена на бутилка")]
        public decimal Price { get; set; }

        
        public IEnumerable<WineTypeServicesModel> Types { get; set; }
         = new List<WineTypeServicesModel>();

    }
}