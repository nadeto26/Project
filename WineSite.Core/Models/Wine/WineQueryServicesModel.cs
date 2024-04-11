namespace WineSite.Core.Models.Wine
{
    public class WineQueryServicesModel
    {
        public int TotalWinesCount { get; set; }

        public IEnumerable<WineServicesModel> Wines { get; set; }
         = new List<WineServicesModel>();
    }
}
