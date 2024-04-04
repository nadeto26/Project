using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WineSite.Data.Constants.More;

namespace WineSite.Data.Models
{
    [Comment("More information about the wine")]
    public class MoreInformation // ще бъде добавено от винаря 
    {
        [Key]
        [Comment("MoreInformation's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Wine's name")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Wine's specifics")]
        [MaxLength(NameSpecificsMaxLength)]
        public string Specifics { get; set; } = null!;

        [Required]
        [Comment("Wine's Notes")]
        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; } = null!;

        [Required]
        [Comment("More information imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("More information description")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public int TypeId { get; set; }

        [Required]
        public int VinarId { get; set; }

        [ForeignKey(nameof(VinarId))]
        public Vinar Vinar { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;
    }
}
