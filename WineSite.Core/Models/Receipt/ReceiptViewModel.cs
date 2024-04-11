using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Data.Common.Constants.More;

namespace WineSite.Core.Models.Receipt
{
    public class ReceiptViewModel
    {
        [Required]
        [Display(Name = "Име")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Необходими продукти")]
        [StringLength(NotesMaxLength, MinimumLength = NotesMinLength)]
        public string Notes { get; set; } = null!;

        [Required]
        [Display(Name = "Снимка Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Начин на приготвяне")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
    }
}
