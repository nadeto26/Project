using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WineSite.Data.Models;

namespace WineSite.Models.Admin
{
    public class WineOrderViewModel
    {
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

        public int WineId { get; set; }

        [ForeignKey(nameof(WineId))]
        public Data.Models.Wine Wine { get; set; } = null!;

        public string WineName { get; set; } = null!;

        public int QuentityWine { get; set; } = 1;
    }

}
