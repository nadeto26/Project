using MessagePack;

namespace WineSite.Models.Event
{
    public class AdminOrdersViewModel
    {
        public string FullName { get; set; } = null!;
        
        public string PostCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal WholePrice { get; set; }

        public string EventName { get; set; } = null!;                  
    }
}
