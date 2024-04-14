namespace WineSite.Core.Models.Wine
{
    public class WineCart
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; } 
    }
}
