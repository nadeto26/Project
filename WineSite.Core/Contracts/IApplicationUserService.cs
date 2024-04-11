namespace WineSite.Core.Contracts
{
    public interface IApplicationUserService
    {
        Task<string> UserFullName(string userId);
    }
}
