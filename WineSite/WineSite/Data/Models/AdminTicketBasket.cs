using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineSite.Data.Models
{
    [Comment("Info for the admin dor the orders of tickets")]
    public class AdminTicketBasket
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int TicketDeliveryId { get; set; }

        [ForeignKey("TicketDeliveryId")]
        public TicketDelivery Delivery { get; set; }

         
        public int  EventId { get; set; }
        public string BuyerId { get; set; }

       
        [ForeignKey("EventId, BuyerId")]
        public TicketBuyer TicketBuyer { get; set; }
    }
}
