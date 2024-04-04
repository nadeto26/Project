namespace WineSite.Contracts
{
    public interface IVinarServices
    {
        public Task<int> GetVinarId(string userId);
    }
}
