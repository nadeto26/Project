using System.ComponentModel.DataAnnotations;

namespace EventsWebsite.Models
{
    public class EventDeleteViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
