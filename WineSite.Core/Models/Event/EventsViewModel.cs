using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Data.Common.Constants.Events;
namespace WineSite.Core.Models.Event
{
    public class EventsViewModel
    {

        [Key]
        [Comment("Event identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Event name")]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
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
        [MinLength(AdressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("Event price for ticket")]
        public decimal PriceTicket { get; set; }

        [Required]
        [Comment("Event description")]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Event WineList")]
        [MaxLength(WineListMaxLength)]
        [MinLength(WineListMinLength)]
        public string WineList { get; set; } = null!;

        [Required]
        [Comment("Event features")]
        [MaxLength(FeaturesMaxLength)]
        [MinLength(FeaturesMinLength)]
        public string Features { get; set; } = null!;

        [Required]
        [Comment("Event preferences")]
        [MaxLength(PreferencesMaxLength)]
        [MinLength(PreferencesMinLength)]
        public string Preferences { get; set; } = null!;

        [Required]
        [Comment("Event moreinformation")]
        [MaxLength(MoreInformationMaxLength)]
        [MinLength(MoreInformationMinLength)]
        public string MoreInformation { get; set; } = null!;

        [Required]
        [Comment("Event HostName")]
        [MaxLength(HostNameMaxLength)]
        [MinLength(HostNameMinLength)]
        public string HostName { get; set; } = null!;
    }
}
