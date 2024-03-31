using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class RecipeConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Recipes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Recipe's necessary ingredients",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Recipe's necessary ingredients");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "Recipe the way of preparation",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Recipe the way of preparation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3247cdc-4c52-4170-996f-13f07f252dde", "AQAAAAEAACcQAAAAELan8RFd6wLhV68K83fsp1ygFCkTyD3juC99XmXcq6T6L4oUebfomxbRz7DooyvQYQ==", "b805f697-78b1-4c2c-a876-d3ef79f32def" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b434507-ea08-435a-b15f-bc35a6766dd1", "AQAAAAEAACcQAAAAEDvTgKq6FAOOtqw0Sr3l1lyDF/aaGIalOnAEeLVhI3YxJaFaqSty+tz+ZqEPuB13MQ==", "c95e8ed2-f8be-4eb9-b95f-1aabc4d9de2e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Recipes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Recipe's necessary ingredients",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Recipe's necessary ingredients");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Recipe the way of preparation",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "Recipe the way of preparation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21995a55-5a03-41bd-94b4-c0d4a45634bb", "AQAAAAEAACcQAAAAEM0WWiIDhYLN3pz+9PXF959kqHnDkdDHew6BgiN35sQx7qKLmWKsWEWOj/i/GDkaOg==", "615640c8-c226-4c9a-931b-16898b8d499e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "622fc758-aa8c-4737-8b4e-0b413ce40783", "AQAAAAEAACcQAAAAEHIeMS7PRcDy5YPROQnqeGAPIBEga+sed3eYHTvmOXLT8Y+YqjfVcYrkBFKcHQuHlw==", "057d0bc7-15fc-45aa-8545-66ff51b349c6" });
        }
    }
}
