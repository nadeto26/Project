using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class BuyerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderWines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    QuentityWine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderWines_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderWines_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b717dfb-522a-4769-befc-32b7a05ec8a8", "AQAAAAEAACcQAAAAEF5xMqYgQlIkdX5ESaZwKleqkxlNLbR8kBhi3tn4sMKYs+8K7kVzPEU5eiq/wgPvyA==", "b97c21b4-8eed-43b0-8f88-b21e98491b27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7138df63-73ab-4e93-a0a4-9ffd88f2b510", "AQAAAAEAACcQAAAAEAtyTtisMYW7GB/bZbS54Y0EDPu7rtV/VQ7V6T2Fe0LUcGQa6IVjXAfCL/bCNuUrNw==", "0cb6c853-ac7e-4c2e-9f63-af3b653d3f08" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderWines_BuyerId",
                table: "OrderWines",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWines_WineId",
                table: "OrderWines",
                column: "WineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e58d6495-4404-4413-9273-0ed0eda9e2c6", "AQAAAAEAACcQAAAAEH8IRnYnYMHwrN5S99jFGf8Qjk2DkBIveetJDK0tVYOSwzHF2Zl6hD+WNqFy4Wz9Eg==", "5d48f711-7a91-46ea-b4b8-9df15e89698f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65be7171-623d-4366-b695-0e697738d76b", "AQAAAAEAACcQAAAAEKfKiM72YAKpWfoR3meKA8UCNi4fXnAvpPPemdqO4gqMPNv/g90od4+bIWP8YsS1Lw==", "d7c71e73-2cf0-4cbb-9f29-dcfc945bb32f" });
        }
    }
}
