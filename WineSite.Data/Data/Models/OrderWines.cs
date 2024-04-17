using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WineSite.Data.Data.Common.Constants.Orders;
namespace WineSite.Data.Data.Models
{
    [Comment("Orders - Wines for the Events")]
    public class OrderWines
    {
        [Key]
        [Comment("WineOrderId")]
        public int Id { get; set; }

        [Required]
        [Comment("Full Name of the user, who is buying the wine")]
        [MaxLength(UserNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [Comment("Adress of the user, who is buying the wine")]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("City of the user, who is buying the wine")]
        public string City { get; set; } = null!;

        [Comment("PhoneNumber  of the user, who is buying the wine")]
        public string Phonenumber { get; set; } = null!;

        [Comment("Email of the user, who is buying the wine")]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("PostCode of the user, who is buying the wine")]
        public string PostCode { get; set; } = null!;

        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int WineId { get; set; }

        [ForeignKey(nameof(WineId))]
        public Wine Wines { get; set; } = null!;

        [Comment("The wine name, that is has been bought by the user")]
        public string WineName { get; set; } = null!;

        [Comment("The  quentity of the wine ,that is has been bought by the user")]
        public int QuentityWine { get; set; } = 1;
    }
}
