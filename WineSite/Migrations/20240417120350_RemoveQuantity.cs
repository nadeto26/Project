using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Web.Migrations
{
    public partial class RemoveQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WholePrice",
                table: "TicketBuyers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c3c01a-c012-4b27-8ca8-2464b97a4e59", "AQAAAAEAACcQAAAAENcx2Xut5EjoCIWyzZwRzBI7ly0aX2DfjoXJDGMhrpBEvLflEdw8UoYd7OiuSrL/mg==", "4ddc2376-a3c4-413c-9376-a6698c94ad0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WholePrice",
                table: "TicketBuyers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "The whole price for the tickets, based on the quantity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b77deae3-2179-493d-a097-a7e2f8c40d9c", "AQAAAAEAACcQAAAAEIlUXwliHJru9M8GCDDLQ1HnFAke6To699kioD1XsQCBC3D9Jzm5CC6gRVFy9cOQkg==", "99db13a2-ade9-4027-bc5f-b7bfd4af89ce" });
        }
    }
}
