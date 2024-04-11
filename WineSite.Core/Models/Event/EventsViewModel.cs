using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WineSite.Core.Models.Event
{
    public class EventsViewModel
    {
        
        [Comment("Event identifier")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Event date and time")]
        public string DateTime { get; set; } = null!; // --> дата и месец и година 

        [Required]
        [Comment("Event Duration")]
        public string Duration { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Event adress")]

        public string Address { get; set; } = null!;

        [Required]
        [Comment("Event price for ticket")]
        public decimal PriceTicket { get; set; }

        [Required]
        [Comment("Event description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Event WineList")]
        public string WineList { get; set; } = null!;

        [Required]
        [Comment("Event features")]
        public string Features { get; set; } = null!;

        [Required]
        [Comment("Event preferences")]
        public string Preferences { get; set; } = null!;

        [Required]
        [Comment("Event moreinformation")]
        public string MoreInformation { get; set; } = null!;

        [Required]
        [Comment("Event HostName")]
        public string HostName { get; set; } = null!;
    }
}
