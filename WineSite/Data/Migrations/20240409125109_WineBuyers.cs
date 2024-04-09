using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class WineBuyers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineBuyers",
                columns: table => new
                {
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineBuyers", x => new { x.WineId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_WineBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineBuyers_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Wine cart");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f25312b0-90fb-4508-879b-8a2789d89610", "AQAAAAEAACcQAAAAEGU1LP4Ab8zGteQjF4DnH8j+DhpB4kPEKdfuvqRCdHCyvA9m3kLNSkERqfRlcPpfSg==", "b44a2324-f893-4871-aa88-d99214f1f24a" });

            migrationBuilder.CreateIndex(
                name: "IX_WineBuyers_BuyerId",
                table: "WineBuyers",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineBuyers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43e12fc9-43c8-4ae8-8818-d5fa5ed42903", "AQAAAAEAACcQAAAAEEbP6eNE8LS/RiThnEFiAYbV0t4h1S5iNUpwl/ZJ0wZ7R0DE4IVWXGgC1eubezKAcw==", "c318903c-43d8-4a37-b072-62ada51090f0" });
        }
    }
}
