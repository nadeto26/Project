using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Data.Models
{
    [Comment("Ticket buyer - cart")]
    public class TicketBuyer
    {
        
        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int EventId { get; set; } 

        [ForeignKey(nameof(EventId))]
        public Events Events { get; set; } = null!;

        [Comment("Quantity for tickets")]
        public int Quantity { get; set; } = 1;

    }
}
