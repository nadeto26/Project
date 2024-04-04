using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Event identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Event date and time"),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Event Duration"),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Event adress"),
                    PriceTicket = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Event price for ticket"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Event description"),
                    WineList = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Event WineList"),
                    Features = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Event features"),
                    Preferences = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Event preferences"),
                    MoreInformation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Event moreinformation"),
                    HostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Event HostName")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Type Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                },
                comment: "Type of wine");

            migrationBuilder.CreateTable(
                name: "Vinar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoreInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "MoreInformation's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's name"),
                    Specifics = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's specifics"),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's Notes"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "More information imageUrl"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "More information description"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    VinarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoreInformation_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoreInformation_Vinar_VinarId",
                        column: x => x.VinarId,
                        principalTable: "Vinar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "More information about the wine");

            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Wine's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's Name"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Wine's year of production"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Wine's imageUrl"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Wine's description"),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Wine's country of production"),
                    Manufucturer = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Wine's manufucturer"),
                    Importer = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Wine's importer"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Wine's price"),
                    Sort = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Wine's sort"),
                    Harvest = table.Column<int>(type: "int", nullable: false, comment: "Wine's harvest"),
                    AlcoholContent = table.Column<int>(type: "int", nullable: false, comment: "Wine's alcohol content in %"),
                    Bottle = table.Column<int>(type: "int", nullable: false, comment: "Wine's bottle in ml"),
                    VinarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wines_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wines_Vinar_VinarId",
                        column: x => x.VinarId,
                        principalTable: "Vinar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Wine");

            migrationBuilder.CreateTable(
                name: "EventWineBuyers",
                columns: table => new
                {
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventWineBuyers", x => new { x.EventId, x.WineId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_EventWineBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventWineBuyers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventWineBuyers_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "8ebc1def-8560-42fd-8f01-9322fdf50403", "ivana.burgilova@gmail.com", false, false, null, "ivana.burgilova@gmail.com", "ivana.burgilova@gmail.com", "AQAAAAEAACcQAAAAEHPMu09HfHtYqb6+/lzxiDuxlXKNfRt3BsCZH9N04d3Cwmzd7Vtj4yl3X05hddX+8g==", null, false, "965f4ee8-bfdb-462a-ae92-27c266bf6def", false, "ivana.burgilova@gmail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "5635e5c0-6895-40d6-81e0-75fe152a7f30", "petarkarapetrov@gmail.com", false, false, null, "petarkarapetrov@gmail.com", "petarkarapetrov@gmail.com", "AQAAAAEAACcQAAAAEF4hgKwnqTls1wsvuXbnD6Ag7uvFZOxAyYszPaNtHAt6qeRcX4nR0eYuwznied6T3w==", null, false, "80618a8b-bb33-4301-aaef-9c2c9b0cdb5b", false, "petarkarapetrov@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Бяло" },
                    { 2, "Червено" },
                    { 3, "Розе" }
                });

            migrationBuilder.InsertData(
                table: "Vinar",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "AlcoholContent", "Bottle", "Country", "Description", "Harvest", "ImageUrl", "Importer", "Manufucturer", "Name", "Price", "Sort", "TypeId", "VinarId", "Year" },
                values: new object[] { 1, 12, 750, "Италия", "Сицилианско био бяло вино от Защитен географски регион (IGP)\r\n\r\nГрило съживява зрелият, бледо жълт цвят с прекрасни златисти оттенъци, интензивно флорално усещане, прекрасно съчетано с аромати на цитрусови плодове. Плътно, сочно и богато, виното разкрива приятен и балансиран вкус и перфектна, хармонична свежест.  Линията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.", 2020, "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1", "„Кооп-търговия и туризъм“  АД", "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy", "Био бялов вино Сицилианско", 9.99m, "Grillo", 1, 1, 2020 });

            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "AlcoholContent", "Bottle", "Country", "Description", "Harvest", "ImageUrl", "Importer", "Manufucturer", "Name", "Price", "Sort", "TypeId", "VinarId", "Year" },
                values: new object[] { 2, 12, 750, "Италия", "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.", 2020, "https://i0.wp.com/coopwine.bg/wp-content/uploads/2022/10/%D0%91%D0%98%D0%9E-%D0%91%D0%AF%D0%9B%D0%9E-%D0%92%D0%98%D0%9D%D0%9E-%D0%93%D0%A0%D0%98%D0%9B%D0%9E-1.png?resize=768%2C494&ssl=1", "„Кооп-търговия и туризъм“  АД", "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy", "Био вино червено Nеro D'Avola", 9.99m, "Grillo", 2, 1, 2020 });

            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "AlcoholContent", "Bottle", "Country", "Description", "Harvest", "ImageUrl", "Importer", "Manufucturer", "Name", "Price", "Sort", "TypeId", "VinarId", "Year" },
                values: new object[] { 3, 12, 750, "Италия", "Сицилианско червено био вино от Защитен географски регион (IGP) \r\n\r\nВино с тъмно лилав цвят. Балансиран вкус и наситен аромат на червени плодове.\r\n\r\nЛинията Био се отличава с органично отгледано грозде, отсъствието на серен диоксид и на добавени сулфити.", 2020, "https://napitka.eu/1376-large_default/vino-roze-jpchenet-cinsault-grenache-025l.jpg", "„Кооп-търговия и туризъм“  АД", "Cantine Sociale Paolini Societa Cooperativa Agricola – Marsala, Italy", "Био вино розе JP.Chenet Cinsault-Grenache", 9.99m, "Grillo", 3, 1, 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_EventWineBuyers_BuyerId",
                table: "EventWineBuyers",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventWineBuyers_WineId",
                table: "EventWineBuyers",
                column: "WineId");

            migrationBuilder.CreateIndex(
                name: "IX_MoreInformation_TypeId",
                table: "MoreInformation",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MoreInformation_VinarId",
                table: "MoreInformation",
                column: "VinarId");

            migrationBuilder.CreateIndex(
                name: "IX_Vinar_UserId",
                table: "Vinar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_TypeId",
                table: "Wines",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_VinarId",
                table: "Wines",
                column: "VinarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventWineBuyers");

            migrationBuilder.DropTable(
                name: "MoreInformation");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Wines");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Vinar");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
