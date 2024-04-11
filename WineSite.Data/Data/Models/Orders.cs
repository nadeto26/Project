using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Data.Models
{
    public class Orders
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

        public string BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Events Events { get; set; } = null!;

        public string EventName { get; set; } = null!;

        public int QuentityEvent { get; set; } = 1;

        
    }
}
