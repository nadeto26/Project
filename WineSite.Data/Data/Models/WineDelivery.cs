using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Data.Common.Constants.WineDelivery;

namespace WineSite.Data.Data.Models
{
    public class WineDelivery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(WineDeliveryNameMaxLength)]
        [Comment("Wine delivery user full name ")]
        public string FullName { get; set; } = null!;

        [Required]
        [Comment("Wine delivery user adress")]
        [MaxLength(WineDeliveryAdressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Comment("Wine delivery user email")]
        [MaxLength(WineDeliveryEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("Wine delivery user phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Comment("Wine delivery city")]
        public string City { get; set; } = null!;

        [Required]
        [Comment("Wine delivery city postcode")]
        public string PostCode { get; set; } = null!;
    }
}
