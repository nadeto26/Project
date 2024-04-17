using Microsoft.EntityFrameworkCore;
using static WineSite.Data.Data.Common.Constants.Wine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Data.Models
{
    [Comment("Wine")]
    public class Wine  
    {
        [Key]
        [Comment("Wine's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Wine's Name")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public Type Type { get; set; } = null!;

        public int TypeId { get; set; }

        [Comment("Wine's year of production")]
        public int Year { get; set; }

        [Required]
        [Comment("Wine's imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Wine's description")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Wine's country of production")]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [Comment("Wine's manufucturer")]
        [MaxLength(ManufucturerMaxLength)]
        public string Manufucturer { get; set; } = null!;

        [Required]
        [Comment("Wine's importer")]
        [MaxLength(ImporterMaxLength)]
        public string Importer { get; set; } = null!;

        [Comment("Wine's price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Comment("Wine's harvest")]
        public int Harvest { get; set; }

        [Comment("Wine's alcohol content in %")]
        public int AlcoholContent { get; set; }

        [Comment("Wine's bottle in ml")]
        public int Bottle  { get; set; }
    }
}
