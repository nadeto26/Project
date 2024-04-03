using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class WineDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine delivery user full name "),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Wine delivery user adress"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine delivery user email"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Wine delivery user phone number"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Wine delivery city"),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Wine delivery city postcode")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineDeliveries", x => x.Id);
                },
                comment: "Info for wine delivery");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1528f99c-46b4-4bc1-aea5-7f69ec4fdc68", "AQAAAAEAACcQAAAAELhHF4NmEOZ7ej0Nw+pf0FAYaNHn8jlfJfMWqf3IVGYXhOTupFDECU5Y6qwPseU+2A==", "8429686d-d7a8-430a-9d55-a2585f8da761" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2ac5ec0-ac96-4154-bdfe-76cf90e9e32c", "AQAAAAEAACcQAAAAEGv10u9mYphNz8rg9Q00wMa+nNhmhz+eBzG2yiAZS67PaNovQK3OMOemxrkGY7XoaQ==", "9ba7cdeb-6522-499e-8b1a-35d3d607f01a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineDeliveries");

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
        }
    }
}
