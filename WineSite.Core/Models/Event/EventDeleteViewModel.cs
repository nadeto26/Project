using System.ComponentModel.DataAnnotations;

namespace WineSite.Core.Models.Event
{
    public class EventDeleteViewModel
    {
        public int Id { get; set; }
   
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
