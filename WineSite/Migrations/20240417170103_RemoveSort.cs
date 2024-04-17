using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Web.Migrations
{
    public partial class RemoveSort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Wines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a039b68-8fa9-4ed5-8226-d7b18e0e29fc", "AQAAAAEAACcQAAAAELd1vBRQIKBj4orROvRgRdOMQTiNib7oqG0f2Jdl6XMDKTAw4riFoYOmWjaYaRzOuA==", "208918ff-29dc-448a-96be-9cffc9e6cf39" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sort",
                table: "Wines",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "Wine's sort");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c3c01a-c012-4b27-8ca8-2464b97a4e59", "AQAAAAEAACcQAAAAENcx2Xut5EjoCIWyzZwRzBI7ly0aX2DfjoXJDGMhrpBEvLflEdw8UoYd7OiuSrL/mg==", "4ddc2376-a3c4-413c-9376-a6698c94ad0d" });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Sort",
                value: "Grillo");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "Sort",
                value: "Grillo");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3,
                column: "Sort",
                value: "Grillo");
        }
    }
}
