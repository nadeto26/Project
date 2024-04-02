using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTicketBasket");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "388ff131-5520-49ca-b0ba-99c0d9516214", "AQAAAAEAACcQAAAAEBrNSQRCTP2ClHrs2Ut6kpF9jKsmMX3cUKbgWCM9W0JqnuwDde/vjdzu4L6MdOp3cA==", "960ae7c5-1090-41ba-a3e8-2cc719bd73d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04f44600-50b1-4f94-bcbd-d4c5e538bbf9", "AQAAAAEAACcQAAAAED8AzmDHyKseqxP9en/gXB/WfVm8h1yrs5oLxRXz3r2ZXTSe4gAmskQeBEvHcfQcsA==", "3ab5e156-e219-4718-8139-75b80320529e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_AdminTicketBasket_TicketBuyers_EventId_BuyerId",
                        columns: x => new { x.EventId, x.BuyerId },
                        principalTable: "TicketBuyers",
                        principalColumns: new[] { "EventId", "BuyerId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminTicketBasket_TicketDeliveries_TicketDeliveryId",
                        column: x => x.TicketDeliveryId,
                        principalTable: "TicketDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Info for the admin dor the orders of tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9e4fea-c9db-453d-90d9-5ff43cd38f8c", "AQAAAAEAACcQAAAAEB6xKclPRrKj4YVpyujTBkuAtJxBdX/tcrdMV46HgDr6G75lDVg/m+9q4VX2qnZTWg==", "4c97f290-0b59-4882-8a77-fbb5c0760b74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "991de6bf-772d-4bb4-a0c8-76a721bae0e1", "AQAAAAEAACcQAAAAEOZG1MeNfkS0zYITidwPYCnRBD0Re/JKSL/XP9yqLcMb8Nl+gymnhLtPXSeAIo61tQ==", "a78c1d40-6e85-498f-9acc-c8139be0774b" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminTicketBasket_EventId_BuyerId",
                table: "AdminTicketBasket",
                columns: new[] { "EventId", "BuyerId" });
        }
    }
}
