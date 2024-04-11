using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventWineBuyers_Events_EventId",
                table: "EventWineBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers");

            migrationBuilder.DropIndex(
                name: "IX_EventWineBuyers_WineId",
                table: "EventWineBuyers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventWineBuyers");

            migrationBuilder.AlterTable(
                name: "EventWineBuyers",
                comment: "Wine cart");

            migrationBuilder.AlterTable(
                name: "Events",
                comment: "Info for events");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Event imageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Events",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Event name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers",
                columns: new[] { "WineId", "BuyerId" });

            migrationBuilder.CreateTable(
                name: "TicketBuyer",
                columns: table => new
                {
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity for tickets"),
                    WholePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The whole price for the tickets, based on the quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBuyer", x => new { x.EventId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_TicketBuyer_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBuyer_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ticket buyer - cart");

            migrationBuilder.CreateTable(
                name: "TicketDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Tickets delivery user full name "),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Tickets delivery user adress"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tickets delivery user phone number"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tickets delivery city"),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tickets delivery city postcode")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDelivery", x => x.Id);
                },
                comment: "Info for ticket delivery");

            migrationBuilder.CreateTable(
                name: "AdminTicketBasket",
                columns: table => new
                {
                    TicketDeliveryId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTicketBasket", x => x.TicketDeliveryId);
                    table.ForeignKey(
                        name: "FK_AdminTicketBasket_TicketBuyer_EventId_BuyerId",
                        columns: x => new { x.EventId, x.BuyerId },
                        principalTable: "TicketBuyer",
                        principalColumns: new[] { "EventId", "BuyerId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminTicketBasket_TicketDelivery_TicketDeliveryId",
                        column: x => x.TicketDeliveryId,
                        principalTable: "TicketDelivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Info for the admin dor the orders of tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c602502-7535-403d-9fdb-470148772d4d", "AQAAAAEAACcQAAAAEK7mp9wzBZ5gJaeo7fMxxAZgbhI/ZaU8kafo4rOKI4OQupmZxGR6K5KUDNBHiTwLzA==", "5081e832-0ecc-4c9f-9d14-2adddbb0faea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce6a1fab-534d-4b31-bc6e-ba71871c89a8", "AQAAAAEAACcQAAAAEDfyrSLRv1Sy5EslO1kqzYEMhnnnyGl5NFTQXnppNla27PFOMB4W3AtiEEPctAb1hQ==", "7e62681b-f5e0-47ae-80fb-7347c944a890" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminTicketBasket_EventId_BuyerId",
                table: "AdminTicketBasket",
                columns: new[] { "EventId", "BuyerId" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketBuyer_BuyerId",
                table: "TicketBuyer",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTicketBasket");

            migrationBuilder.DropTable(
                name: "TicketBuyer");

            migrationBuilder.DropTable(
                name: "TicketDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Events");

            migrationBuilder.AlterTable(
                name: "EventWineBuyers",
                oldComment: "Wine cart");

            migrationBuilder.AlterTable(
                name: "Events",
                oldComment: "Info for events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventWineBuyers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers",
                columns: new[] { "EventId", "WineId", "BuyerId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3247cdc-4c52-4170-996f-13f07f252dde", "AQAAAAEAACcQAAAAELan8RFd6wLhV68K83fsp1ygFCkTyD3juC99XmXcq6T6L4oUebfomxbRz7DooyvQYQ==", "b805f697-78b1-4c2c-a876-d3ef79f32def" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b434507-ea08-435a-b15f-bc35a6766dd1", "AQAAAAEAACcQAAAAEDvTgKq6FAOOtqw0Sr3l1lyDF/aaGIalOnAEeLVhI3YxJaFaqSty+tz+ZqEPuB13MQ==", "c95e8ed2-f8be-4eb9-b95f-1aabc4d9de2e" });

            migrationBuilder.CreateIndex(
                name: "IX_EventWineBuyers_WineId",
                table: "EventWineBuyers",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventWineBuyers_Events_EventId",
                table: "EventWineBuyers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
