﻿using Microsoft.AspNetCore.Identity;
using WineSite.Data.Models;
using Type = WineSite.Data.Models.Type;
 

namespace WineSite.Data.SeedDb
{
    public class SeedData
    {
        public ApplicationUser VinarUser { get; set; }

        public ApplicationUser GuestUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public Vinar Vinar { get; set; }

        public Type WhiteWine { get; set; }

        public Type RoseWine { get; set; }

        public Type RedWine { get; set; }

        public Wine FirstWine { get; set; }

        public Wine SecondWine { get; set; }

        public Wine ThirdWine { get; set; }

        public EventWineBuyer EventWineBuyer { get; set; }

         


        public SeedData()
        {
            SeedUsers();
            SeedVinar();
            SeedType();
            SeedWine();
        }

       
        private void SeedWine()
        {
            FirstWine = new Wine()
            {
                Id = 1,
                Name = "Био бялов вино Сицилианско",
                TypeId = WhiteWine.Id,
                Year = 2020,
                Description = "Сицилианско био бяло вино от Защитен географски регион (IGP)\r\n\r\nГрило съживява зрелият, бледо жълт цвят с прекрасни златисти оттенъци, интензивно флорално усещане, прекрасно съчетано с аромати на цитрусови плодове. Плътно, сочно и богато, виното разкрива приятен и балансиран вкус и перфектна, хармонична свежест.  Линията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                Price = 9.99M,
                Country = "Италия",
                Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                Importer = "„Кооп-търговия и туризъм“  АД",
                Sort = "Grillo",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
                VinarId = Vinar.Id
            };
            SecondWine = new Wine()
            {
                Id = 2,
                Name = "Био вино червено Nеro D'Avola",
                TypeId = RedWine.Id,
                Year = 2020,
                Description = "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                Price = 9.99M,
                Country = "Италия",
                Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                Importer = "„Кооп-търговия и туризъм“  АД",
                Sort = "Grillo",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
                VinarId = Vinar.Id
            };
            ThirdWine = new Wine()
            {
                Id = 3,
                Name = "Био вино розе JP.Chenet Cinsault-Grenache",
                TypeId = RoseWine.Id,
                Year = 2020,
                Description = "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                ImageUrl = "https://napitka.eu/1376-large_default/vino-roze-jpchenet-cinsault-grenache-025l.jpg",
                Price = 9.99M,
                Country = "Италия",
                Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                Importer = "„Кооп-търговия и туризъм“  АД",
                Sort = "Grillo",
                Harvest = 2020,
                AlcoholContent = 12,
                Bottle = 750,
                VinarId = Vinar.Id
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            VinarUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "petarkarapetrov@gmail.com",
                NormalizedUserName = "petarkarapetrov@gmail.com",
                Email = "petarkarapetrov@gmail.com",
                NormalizedEmail = "petarkarapetrov@gmail.com",
                FirstName = "Petar",
                LastName = "Karapetrov"
            };

            VinarUser.PasswordHash =
                 hasher.HashPassword(VinarUser, "vinar123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "ivana.burgilova@gmail.com",
                NormalizedUserName = "ivana.burgilova@gmail.com",
                Email = "ivana.burgilova@gmail.com",
                NormalizedEmail = "ivana.burgilova@gmail.com",
                FirstName = "Ivana",
                LastName = "Burgilova"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "100205-Ib");

            AdminUser = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = "nadezhda.karapetrova@pmggd.bg",
                NormalizedEmail = "nadezhda.karapetrova@pmggd.bg",
                UserName = "nadezhda.karapetrova@pmggd.bg",
                NormalizedUserName = "nadezhda.karapetrova@pmggd.bg",
                FirstName = "Nadezhda",
                LastName = "Karapetrova"
            };

            AdminUser.PasswordHash = hasher.HashPassword(VinarUser, "admin123");

        }

        private void SeedType()
        {
            WhiteWine = new Type()
            {
                Id = 1,
                Name = "Бяло"
            };
            RedWine = new Type()
            {
                Id = 2,
                Name = "Червено"
            };
            RoseWine = new Type()
            {
                Id = 3,
                Name = "Розе"
            };
        }

        private void SeedVinar()
        {
            Vinar = new Vinar()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = VinarUser.Id
            };
        }

        
    }
}
