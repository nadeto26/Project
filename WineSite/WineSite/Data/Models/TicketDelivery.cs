using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Constants.TicketDelivery;
namespace WineSite.Data.Models
{
    [Comment("Info for ticket delivery")]
    public class TicketDelivery
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        [MaxLength(TicketDeliveryNameMaxLength)]
        [Comment("Tickets delivery user full name ")]
        public string FullName { get; set; } = null!;

        [Required]
        [Comment("Tickets delivery user adress")]
        [MaxLength(TicketDeliveryAdressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("Tickets delivery user phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Comment("Tickets delivery city")]
        public string City { get; set; } = null!;

        [Required]
        [Comment("Tickets delivery city postcode")]
        public string PostCode { get; set; } = null!;
    }
}
