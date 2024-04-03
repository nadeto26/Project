using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class WineBuyerQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bff22ff4-42e7-4c82-9edf-5b4d5dd33dfb", "AQAAAAEAACcQAAAAEH62fJwgTh46jG+nPeW/Kf8oSIB8KlpjYpaImTqZBTDV+3pDJINcXcL1Q8YjTNRfZg==", "508560ff-7460-4c38-bf32-6c1ec719ddae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e84e618-cb84-4674-9079-2b510582fcc3", "AQAAAAEAACcQAAAAEO9iNHugRumEIT0twhhVTyBMPjKVVTJtGBU92Lc6BzR8zK4arB9iNFUGwcn9ybu1Zw==", "a3b396f2-e504-4b0b-b2df-be1438327f8e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Wines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d7bee03-7c44-4ac5-83cd-feac9882fd35", "AQAAAAEAACcQAAAAEKZLTWquTTpw/Tnk1UxMizkcYN0itsmEHCkVR7fGrMZ7B8IursQ1JeI4bfZDZNix4g==", "f2c52405-1293-40a7-8270-29ca87fbcab0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "392d1872-4800-4bfd-986f-d7c11cce2fc2", "AQAAAAEAACcQAAAAEDX8pz7Dd6NuhZ/ZiUjr8do9UJA1xOpFhN+E5rnwVJtnTK9puda8LL/eSXRKcO8orA==", "d1fe6c8a-ed45-4277-8f41-fbb2e686175c" });
        }
    }
}
