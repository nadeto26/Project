using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class Recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoreInformation");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Recipe's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Recipe's name"),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Recipe's necessary ingredients"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Recipe imageUrl"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Recipe the way of preparation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                },
                comment: "Recipe");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.CreateTable(
                name: "MoreInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "MoreInformation's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "More information description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "More information imageUrl"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's name"),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's Notes"),
                    Specifics = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Wine's specifics")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoreInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoreInformation_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "More information about the wine");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17999be6-c2cb-4ebd-af6c-de79ece92c4f", "AQAAAAEAACcQAAAAEL4l/XkjPBxpVTvjuwZGXCo4zb/BfHU0wRmqwl3MWSeSCO53UH2MJWG10VxqWytZlg==", "78f501de-bae4-4c3b-90a5-61e94b2c9cec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6e5c523-8130-4de4-af88-cbc0c9703365", "AQAAAAEAACcQAAAAEM4lbvZB3nA3RWbaXhGGy3ofnV8/wZj2dkcaZ4voJz0GtuEjSc+MNAaJDDRsv8NhEg==", "9ceee0cd-05af-4f6c-826a-d18cfeafbdb1" });

            migrationBuilder.CreateIndex(
                name: "IX_MoreInformation_TypeId",
                table: "MoreInformation",
                column: "TypeId");
        }
    }
}
