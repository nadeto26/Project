﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WineSite.Contracts;
using WineSite.Data;
using WineSite.Infrastructure;
using WineSite.Models.Wine;
using WineSite.Services.Wine.Models;

namespace WineSite.Services
{
    public class WineServices : IWineServices
    {
        private readonly WineShopDbContext _db;
        
        public WineServices(WineShopDbContext db)
        {
            _db = db;
        }

        public WineQueryServicesModel All(string type = null, string searchItem = null, WineSorting sorting = WineSorting.Newest, int currentPage = 1, int wineperPage = 1)
        {
            var winesQuery = _db.Wines.AsQueryable();

            if(!string.IsNullOrEmpty(type))
            {
                winesQuery = _db.Wines
                    .Where(t => t.Type.Name == type);
            }

            if(!string.IsNullOrEmpty(searchItem))
            {
                winesQuery = winesQuery
                    .Where(w=> 
                    w.Name.ToLower().Contains(searchItem.ToLower())
                    || w.Description.ToLower().Contains(searchItem.ToLower())
                    || w.Country.ToLower().Contains(searchItem.ToLower()));
            }

            winesQuery = sorting switch
            {
                WineSorting.Price => winesQuery
                .OrderBy(t => t.Price),
                WineSorting.Newest => winesQuery
                .OrderBy(w => w.Name)
                .ThenByDescending(w => w.Id),
                _=> winesQuery.OrderByDescending(w => w.Id)
            };

            var wines = winesQuery
                .Skip((currentPage - 1) * wineperPage)
                .Take(wineperPage)
                .Select(w => new WineServicesModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    ImageUrl = w.ImageUrl,
                    Price = w.Price,
                    Year = w.Year,

                }).ToList();

            var totalWines = winesQuery.Count();

            return new WineQueryServicesModel()
            {
                TotalWinesCount = totalWines,
                Wines = wines
            };
               
        }

        

        public async Task<IEnumerable<WineTypeServicesModel>> AllTypes()
        {
            return await _db
                .Wines.Select(w => new WineTypeServicesModel
                {
                    Name = w.Name,
                    Id = w.Id,
                }).ToListAsync();

        }

        public async Task<IEnumerable<string>> AllTypesName()
        {
             return await _db.Types
                .Select(t=>t.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> Create(string name, int typeId, int year, string imageUrl, string description, string country, 
            string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle,int vinarId)
        {
            var wine = new WineSite.Data.Models.Wine()
            {
                Name = name,
                TypeId = typeId,
                Year = year,
                ImageUrl = imageUrl,
                Description = description,
                Country = country,
                Manufucturer = manufucturer,
                Price = price,
                Sort = sort,
                Harvest = harvest,
                Bottle = bottle,
                VinarId = vinarId,
                AlcoholContent = alcoholcontent
            };

            await _db.Wines.AddRangeAsync(wine);
            await _db.SaveChangesAsync();

            return wine.Id;
        }

        public async Task Edit(int wineId, string name, int typeId, int year, string imageUrl, string description, 
            string country, string manufucturer, decimal price, string sort, int harvest, int alcoholcontent, int bottle)
        {
             var wine = _db.Wines.Find(wineId);

             wine.Name = name;
             wine.TypeId = typeId;
             wine.Year = year;
             wine.ImageUrl = imageUrl;
             wine.Description = description;
             wine.Country = country;
             wine.Manufucturer = manufucturer;
             wine.Price = price;
             wine.Sort = sort;
             wine.Harvest = harvest;
             wine.Bottle = bottle;
             wine.Harvest = harvest;
             wine.AlcoholContent = alcoholcontent;
             wine.Bottle = bottle;

            await _db.SaveChangesAsync();

        }

        public async Task<bool> Exist(int id)
        {
            return await _db.Wines.AnyAsync(wine => wine.Id == id);
        }

        public async Task<bool> TypeExist(int typeId)
        {
           return await _db.Types.AnyAsync(c=>c.Id == typeId);
        }

        public async Task<WineDetailsSevicesModel> WineDetailsById(int id)
        {
            return await _db.Wines
               .Where(w => w.Id == id)
               .Select(w => new WineDetailsSevicesModel()
               {
                   Id = w.Id,
                   Name = w.Name,
                   Type = w.Type.Name,
                   Description = w.Description,
                   Country = w.Country,
                   Manufucturer = w.Manufucturer,
                   Year = w.Year,
                   Harvest = w.Harvest,
                   Bottle = w.Bottle,
                   AlcoholContent = w.AlcoholContent,
                   ImageUrl = w.ImageUrl,
                   Importer = w.Importer,
                   Price = w.Price

               }).FirstOrDefaultAsync();
                
        }


    }
}
