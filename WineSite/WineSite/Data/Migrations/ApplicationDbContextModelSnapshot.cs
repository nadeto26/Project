﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WineSite.Data;

#nullable disable

namespace WineSite.Data.Migrations
{
    [DbContext(typeof(WineShopDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WineSite.Data.Models.AdminTicketBasket", b =>
                {
                    b.Property<int>("TicketDeliveryId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("TicketDeliveryId");

                    b.HasIndex("EventId", "BuyerId");

                    b.ToTable("AdminTicketBasket");

                    b.HasComment("Info for the admin dor the orders of tickets");
                });

            modelBuilder.Entity("WineSite.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "991de6bf-772d-4bb4-a0c8-76a721bae0e1",
                            Email = "petarkarapetrov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Petar",
                            LastName = "Karapetrov",
                            LockoutEnabled = false,
                            NormalizedEmail = "petarkarapetrov@gmail.com",
                            NormalizedUserName = "petarkarapetrov@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOZG1MeNfkS0zYITidwPYCnRBD0Re/JKSL/XP9yqLcMb8Nl+gymnhLtPXSeAIo61tQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a78c1d40-6e85-498f-9acc-c8139be0774b",
                            TwoFactorEnabled = false,
                            UserName = "petarkarapetrov@gmail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cf9e4fea-c9db-453d-90d9-5ff43cd38f8c",
                            Email = "ivana.burgilova@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ivana",
                            LastName = "Burgilova",
                            LockoutEnabled = false,
                            NormalizedEmail = "ivana.burgilova@gmail.com",
                            NormalizedUserName = "ivana.burgilova@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEB6xKclPRrKj4YVpyujTBkuAtJxBdX/tcrdMV46HgDr6G75lDVg/m+9q4VX2qnZTWg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4c97f290-0b59-4882-8a77-fbb5c0760b74",
                            TwoFactorEnabled = false,
                            UserName = "ivana.burgilova@gmail.com"
                        });
                });

            modelBuilder.Entity("WineSite.Data.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Event identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Event adress");

                    b.Property<string>("DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Event date and time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Event description");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Event Duration");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Event features");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Event HostName");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Event imageUrl");

                    b.Property<string>("MoreInformation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Event moreinformation");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Event name");

                    b.Property<string>("Preferences")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Event preferences");

                    b.Property<decimal>("PriceTicket")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Event price for ticket");

                    b.Property<string>("WineList")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Event WineList");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasComment("Info for events");
                });

            modelBuilder.Entity("WineSite.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Recipe's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Recipe the way of preparation");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Recipe imageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Recipe's name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Recipe's necessary ingredients");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasComment("Recipe");
                });

            modelBuilder.Entity("WineSite.Data.Models.TicketBuyer", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Quantity for tickets");

                    b.Property<decimal>("WholePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("The whole price for the tickets, based on the quantity");

                    b.HasKey("EventId", "BuyerId");

                    b.HasIndex("BuyerId");

                    b.ToTable("TicketBuyers");

                    b.HasComment("Ticket buyer - cart");
                });

            modelBuilder.Entity("WineSite.Data.Models.TicketDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Tickets delivery user adress");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Tickets delivery city");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Tickets delivery user full name ");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Tickets delivery user phone number");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Tickets delivery city postcode");

                    b.HasKey("Id");

                    b.ToTable("TicketDeliveries");

                    b.HasComment("Info for ticket delivery");
                });

            modelBuilder.Entity("WineSite.Data.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Type Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Type Name");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasComment("Type of wine");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Червено"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Розе"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Бяло"
                        });
                });

            modelBuilder.Entity("WineSite.Data.Models.Vinar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vinar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        });
                });

            modelBuilder.Entity("WineSite.Data.Models.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Wine's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlcoholContent")
                        .HasColumnType("int")
                        .HasComment("Wine's alcohol content in %");

                    b.Property<int>("Bottle")
                        .HasColumnType("int")
                        .HasComment("Wine's bottle in ml");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Wine's country of production");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Wine's description");

                    b.Property<int>("Harvest")
                        .HasColumnType("int")
                        .HasComment("Wine's harvest");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Wine's imageUrl");

                    b.Property<string>("Importer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Wine's importer");

                    b.Property<string>("Manufucturer")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Wine's manufucturer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Wine's Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Wine's price");

                    b.Property<string>("Sort")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Wine's sort");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("VinarId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("Wine's year of production");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("VinarId");

                    b.ToTable("Wines");

                    b.HasComment("Wine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlcoholContent = 12,
                            Bottle = 750,
                            Country = "Италия",
                            Description = "Сицилианско био бяло вино от Защитен географски регион (IGP)\r\n\r\nГрило съживява зрелият, бледо жълт цвят с прекрасни златисти оттенъци, интензивно флорално усещане, прекрасно съчетано с аромати на цитрусови плодове. Плътно, сочно и богато, виното разкрива приятен и балансиран вкус и перфектна, хармонична свежест.  Линията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                            Harvest = 2020,
                            ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                            Importer = "„Кооп-търговия и туризъм“  АД",
                            Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                            Name = "Био бялов вино Сицилианско",
                            Price = 9.99m,
                            Sort = "Grillo",
                            TypeId = 1,
                            VinarId = 1,
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            AlcoholContent = 12,
                            Bottle = 750,
                            Country = "Италия",
                            Description = "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                            Harvest = 2020,
                            ImageUrl = "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1",
                            Importer = "„Кооп-търговия и туризъм“  АД",
                            Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                            Name = "Био вино червено Nеro D'Avola",
                            Price = 9.99m,
                            Sort = "Grillo",
                            TypeId = 2,
                            VinarId = 1,
                            Year = 2020
                        },
                        new
                        {
                            Id = 3,
                            AlcoholContent = 12,
                            Bottle = 750,
                            Country = "Италия",
                            Description = "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.",
                            Harvest = 2020,
                            ImageUrl = "https://napitka.eu/1376-large_default/vino-roze-jpchenet-cinsault-grenache-025l.jpg",
                            Importer = "„Кооп-търговия и туризъм“  АД",
                            Manufucturer = "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy",
                            Name = "Био вино розе JP.Chenet Cinsault-Grenache",
                            Price = 9.99m,
                            Sort = "Grillo",
                            TypeId = 3,
                            VinarId = 1,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("WineSite.Data.Models.WineBuyer", b =>
                {
                    b.Property<int>("WineId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WineId", "BuyerId");

                    b.HasIndex("BuyerId");

                    b.ToTable("EventWineBuyers");

                    b.HasComment("Wine cart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineSite.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WineSite.Data.Models.AdminTicketBasket", b =>
                {
                    b.HasOne("WineSite.Data.Models.TicketDelivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("TicketDeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineSite.Data.Models.TicketBuyer", "TicketBuyer")
                        .WithMany()
                        .HasForeignKey("EventId", "BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("TicketBuyer");
                });

            modelBuilder.Entity("WineSite.Data.Models.TicketBuyer", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineSite.Data.Models.Events", "Events")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("WineSite.Data.Models.Vinar", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WineSite.Data.Models.Wine", b =>
                {
                    b.HasOne("WineSite.Data.Models.Type", "Type")
                        .WithMany("Wines")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WineSite.Data.Models.Vinar", "Vinar")
                        .WithMany("Wines")
                        .HasForeignKey("VinarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("Vinar");
                });

            modelBuilder.Entity("WineSite.Data.Models.WineBuyer", b =>
                {
                    b.HasOne("WineSite.Data.Models.ApplicationUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WineSite.Data.Models.Wine", "Wine")
                        .WithMany()
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("WineSite.Data.Models.Type", b =>
                {
                    b.Navigation("Wines");
                });

            modelBuilder.Entity("WineSite.Data.Models.Vinar", b =>
                {
                    b.Navigation("Wines");
                });
#pragma warning restore 612, 618
        }
    }
}
