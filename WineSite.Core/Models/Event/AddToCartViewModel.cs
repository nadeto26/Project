namespace WineSite.Core.Models.Event
{
    public class AddToCartViewModel
    {
        public int Id { get; set; }

        public string TicketName { get; set; } = null!;

        public decimal PricePerTicket { get; set; } 

        public string ImageUrl { get; set; } = null!;

        public int Quentity { get; set; }

        public int EventId { get; set; }
    }
}
