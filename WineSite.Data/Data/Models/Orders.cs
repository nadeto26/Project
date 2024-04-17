using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static WineSite.Data.Data.Common.Constants.Orders;

namespace WineSite.Data.Data.Models
{
    [Comment("Orders - Tickets for the Events")]
    public class Orders
    {
        [Key]
        [Comment("TicketOrderId")]
        public int Id { get; set; }

        [Required]
        [Comment("Full Name of the user, who is buying the ticket")]
        [MaxLength(UserNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [Comment("Address of the user, who is buying the ticket")]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("City the user, who is buying the ticket")]
        public string City { get; set; } = null!;

        [Comment("PhoneNumber of the user, who is buying the ticket")]
        public string Phonenumber { get; set; } = null!;

        [Comment("Email of the user, who is buying the ticket")]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("PostCode of the user, who is buying the ticket")]
        public string PostCode { get; set; } = null!;

        public string BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Events Events { get; set; } = null!;

        [Comment("The event name")]
        public string EventName { get; set; } = null!;

        [Comment("The quentity of the bought tickets")]
        public int QuentityEvent { get; set; } = 1;

        
    }
}
