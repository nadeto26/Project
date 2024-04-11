using System.ComponentModel.DataAnnotations;
using WineSite.Core.Infrastructure;

namespace WineSite.Core.Models.Wine
{
    public class AllWinesQuaryModel
    {
        public const int WinePerPage = 3;

        public string Type { get; set; } = null!;

        [Display(Name ="Search by text")]
        public string SearchItem { get; set; } = null!;

        public WineSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalWinesCount { get; set; }

        public IEnumerable<string> Types { get; set; } = null!;

        public IEnumerable<WineServicesModel> Wines { get; set; }
        = new List<WineServicesModel>();
    }
}
