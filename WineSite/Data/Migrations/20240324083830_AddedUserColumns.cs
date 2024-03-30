using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f80f1e7d-603a-4689-88d1-7a4a0a8508dd", "Ivana", "Burgilova", "AQAAAAEAACcQAAAAEBeBCVP0RyN8vGT3qcRJ9RPRswuuy0Waj0Te86KNw0pTIdU5ZiVtsa7QDFwQVFTW5g==", "1a9676be-f551-45d5-914c-8fb6a5954350" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a54da83-7620-477f-962b-8013f529bf06", "Petar", "Karapetrov", "AQAAAAEAACcQAAAAEDQ3RlWI72tGZx30IzVlyQLvTbv4FWbdXGPAeGYARcx/bLTiqvYh9feN+k2U2PMXUg==", "abf489ba-9ce7-4531-ae94-c78d939c9da3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ebc1def-8560-42fd-8f01-9322fdf50403", "AQAAAAEAACcQAAAAEHPMu09HfHtYqb6+/lzxiDuxlXKNfRt3BsCZH9N04d3Cwmzd7Vtj4yl3X05hddX+8g==", "965f4ee8-bfdb-462a-ae92-27c266bf6def" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5635e5c0-6895-40d6-81e0-75fe152a7f30", "AQAAAAEAACcQAAAAEF4hgKwnqTls1wsvuXbnD6Ag7uvFZOxAyYszPaNtHAt6qeRcX4nR0eYuwznied6T3w==", "80618a8b-bb33-4301-aaef-9c2c9b0cdb5b" });
        }
    }
}
