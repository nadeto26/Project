using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Models
{
    [Comment("Wine cart")]
    public class WineBuyers
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

        public int Quantity { get; set; }

    }
}
