using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Models
{
    [Comment("Ticket buyer - cart")]
    public class TicketBuyer
    {
        [Key]
        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        [Key]
        public int EventId { get; set; } 

        [ForeignKey(nameof(EventId))]
        public Events Events { get; set; } = null!;

        [Comment("Quantity for tickets")]
        public int Quantity { get; set; } = 1;

        [Comment("The whole price for the tickets, based on the quantity")]
        public decimal WholePrice  { get; set; } 
    }
}
