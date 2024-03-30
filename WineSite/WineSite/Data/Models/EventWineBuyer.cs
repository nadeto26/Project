 
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Models
{
    public class EventWineBuyer //количката, ще купуват -> вино и запазват събития 
    {
        [Required]
        public string BuyerId { get; set; } = null!;

        [Required]
        [ForeignKey("BuyerId")]
        public ApplicationUser Buyer { get; set; } = null!;

        [Required]
        public int WineId { get; set; }

        [Required]
        [ForeignKey("WineId")]
        public Wine Wine { get; set; } = null!;

        [Required]
        public int EventId { get; set; }

        [Required]
        [ForeignKey("EventId")]
        public Events Events { get; set; } = null!;

    }
}
