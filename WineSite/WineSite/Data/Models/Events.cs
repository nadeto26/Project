using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Constants.Events;

namespace WineSite.Data.Models
{
    [Comment("Info for events")]
    public class Events // ще бъде добавено от админа 
    {
        [Key]
        [Comment("Event identifier")]
        public int Id { get; set; }  

        [Required]
        [Comment("Event name")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Event imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Event date and time")]
        public string DateTime { get; set; } = null!; // --> дата и месец и година 

        [Required]
        [Comment("Event Duration")]
        public string Duration { get; set; } = null!;

        [Required]
        [Comment("Event adress")]
        [MaxLength(AdressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("Event price for ticket")]
        public decimal PriceTicket { get; set; }

        [Required]
        [Comment("Event description")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Event WineList")]
        [MaxLength(WineListMaxLength)]
        public string WineList { get; set; } = null!;

        [Required]
        [Comment("Event features")]
        [MaxLength(FeaturesMaxLength)]
        public string Features { get; set; } = null!;

        [Required]
        [Comment("Event preferences")]
        [MaxLength(PreferencesMaxLength)]
        public string Preferences { get; set; } = null!;

        [Required]
        [Comment("Event moreinformation")]
        [MaxLength(MoreInformationMaxLength)]
        public string MoreInformation { get; set; } = null!;

        [Required]
        [Comment("Event HostName")]
        [MaxLength(HostNameMaxLength)]
        public string HostName { get; set; } = null!;
    }
}
