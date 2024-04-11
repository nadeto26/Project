using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class AdDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminTicketBasket_TicketBuyer_EventId_BuyerId",
                table: "AdminTicketBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTicketBasket_TicketDelivery_TicketDeliveryId",
                table: "AdminTicketBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketBuyer_AspNetUsers_BuyerId",
                table: "TicketBuyer");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketBuyer_Events_EventId",
                table: "TicketBuyer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDelivery",
                table: "TicketDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketBuyer",
                table: "TicketBuyer");

            migrationBuilder.RenameTable(
                name: "TicketDelivery",
                newName: "TicketDeliveries");

            migrationBuilder.RenameTable(
                name: "TicketBuyer",
                newName: "TicketBuyers");

            migrationBuilder.RenameIndex(
                name: "IX_TicketBuyer_BuyerId",
                table: "TicketBuyers",
                newName: "IX_TicketBuyers_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDeliveries",
                table: "TicketDeliveries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketBuyers",
                table: "TicketBuyers",
                columns: new[] { "EventId", "BuyerId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTicketBasket_TicketBuyers_EventId_BuyerId",
                table: "AdminTicketBasket",
                columns: new[] { "EventId", "BuyerId" },
                principalTable: "TicketBuyers",
                principalColumns: new[] { "EventId", "BuyerId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTicketBasket_TicketDeliveries_TicketDeliveryId",
                table: "AdminTicketBasket",
                column: "TicketDeliveryId",
                principalTable: "TicketDeliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBuyers_AspNetUsers_BuyerId",
                table: "TicketBuyers",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBuyers_Events_EventId",
                table: "TicketBuyers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminTicketBasket_TicketBuyers_EventId_BuyerId",
                table: "AdminTicketBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminTicketBasket_TicketDeliveries_TicketDeliveryId",
                table: "AdminTicketBasket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketBuyers_AspNetUsers_BuyerId",
                table: "TicketBuyers");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketBuyers_Events_EventId",
                table: "TicketBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDeliveries",
                table: "TicketDeliveries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketBuyers",
                table: "TicketBuyers");

            migrationBuilder.RenameTable(
                name: "TicketDeliveries",
                newName: "TicketDelivery");

            migrationBuilder.RenameTable(
                name: "TicketBuyers",
                newName: "TicketBuyer");

            migrationBuilder.RenameIndex(
                name: "IX_TicketBuyers_BuyerId",
                table: "TicketBuyer",
                newName: "IX_TicketBuyer_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDelivery",
                table: "TicketDelivery",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketBuyer",
                table: "TicketBuyer",
                columns: new[] { "EventId", "BuyerId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTicketBasket_TicketBuyer_EventId_BuyerId",
                table: "AdminTicketBasket",
                columns: new[] { "EventId", "BuyerId" },
                principalTable: "TicketBuyer",
                principalColumns: new[] { "EventId", "BuyerId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTicketBasket_TicketDelivery_TicketDeliveryId",
                table: "AdminTicketBasket",
                column: "TicketDeliveryId",
                principalTable: "TicketDelivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBuyer_AspNetUsers_BuyerId",
                table: "TicketBuyer",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBuyer_Events_EventId",
                table: "TicketBuyer",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
