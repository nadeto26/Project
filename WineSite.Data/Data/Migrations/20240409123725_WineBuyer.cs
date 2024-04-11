using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class WineBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

             

           
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderWines");

            migrationBuilder.DropTable(
                name: "WineDeliveries");

            migrationBuilder.CreateTable(
                name: "EventWineBuyers",
                columns: table => new
                {
                    WineId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventWineBuyers", x => new { x.WineId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_EventWineBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventWineBuyers_Wines_WineId",
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
                values: new object[] { "ebec3f44-8317-4561-8f9d-2a770a4a2517", "AQAAAAEAACcQAAAAEPs/hosmZEvNqseCb1u7bHTXJ7Ryx3/jVlC0sj4pjz6wmZs+vhBBGLgBC+L+YdYZOw==", "84d1c0d3-90b8-483a-b13f-7e21a3f28df5" });

            migrationBuilder.CreateIndex(
                name: "IX_EventWineBuyers_BuyerId",
                table: "EventWineBuyers",
                column: "BuyerId");
        }
    }
}
