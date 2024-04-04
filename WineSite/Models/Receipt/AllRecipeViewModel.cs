using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WineSite.Models.Receipt
{
    public class AllRecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Notes { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
