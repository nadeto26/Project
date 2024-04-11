using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WineSite.Data.Data.Common.Constants.More;

namespace WineSite.Data.Data.Models
{
    [Comment("Recipe")]
    public class Recipe 
    {
        [Key]
        [Comment("Recipe's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Recipe's name")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Recipe's necessary ingredients")]
        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; } = null!;

        [Required]
        [Comment("Recipe imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Recipe the way of preparation")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
