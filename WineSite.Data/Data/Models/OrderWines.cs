using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Data.Models
{
    public class OrderWines
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        public string Phonenumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required]
        public string PostCode { get; set; } = null!;

        public string BuyerId { get; set; } = null!;

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int WineId { get; set; }

        [ForeignKey(nameof(WineId))]
        public Wine Wines { get; set; } = null!;

        public string WineName { get; set; } = null!;

        public int QuentityWine { get; set; } = 1;
    }
}
