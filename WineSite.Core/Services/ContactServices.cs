using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineSite.Core.Contracts;
using WineSite.Core.Models.Contact;
using WineSite.Data.Data;
using WineSite.Data.Data.Models;

namespace WineSite.Core.Services
{
    public class ContactServices : IContactServices
    {
        private readonly WineShopDbContext _dbContext;
        public ContactServices(WineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMessageAsync(AddMessage model)
        {
            var adMessage = new Messages()
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                About = model.About,
                Message = model.Message,
            };
            await _dbContext.Messages.AddAsync(adMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
