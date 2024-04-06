using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using WineSite.Models.Event;

namespace WineSite.Contracts
{
    public interface IEventServices
    {
        Task<bool> ExistAsync(int id);

        Task<EventsViewModel?> GetEventDetailsByIdAsync(int id);

        Task<int> GetEventTicketBuyersCountAsync(int id);

        Task<List<EventsViewModel>> GetAllEventsAsync();

        Task AddTicketDeliveryAsync(DeliveryDetailsViewModel deliveryDetails);

        Task ConfirmOrderAsync(string userId);

        Task<bool> AddEventToCartAsync(int eventId, string userId);

        Task<List<AddToCartViewModel>> GetUserTicketsAsync(string userId);
    }
}
