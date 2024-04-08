using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class Removing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Vinar_VinarId",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "Vinar");

            migrationBuilder.DropIndex(
                name: "IX_Wines_VinarId",
                table: "Wines");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "VinarId",
                table: "Wines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebec3f44-8317-4561-8f9d-2a770a4a2517", "AQAAAAEAACcQAAAAEPs/hosmZEvNqseCb1u7bHTXJ7Ryx3/jVlC0sj4pjz6wmZs+vhBBGLgBC+L+YdYZOw==", "84d1c0d3-90b8-483a-b13f-7e21a3f28df5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VinarId",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vinar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62621c88-af1d-437a-8162-3b41094a2dba", "AQAAAAEAACcQAAAAEBh4Zv3NN3P5QLJQgZC6srAtKurD4wWxbHbPvvNWjCj7uMsHza5aD9gdHdgsUC0PDQ==", "36b08cd0-feff-48fb-b3df-044e94942aa3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6d0bc094-9599-4cc8-925b-04c6789502fb", "petarkarapetrov@gmail.com", false, "Petar", "Karapetrov", false, null, "petarkarapetrov@gmail.com", "petarkarapetrov@gmail.com", "AQAAAAEAACcQAAAAEEHNF655nTxLtn+2bGk8ckw1UN5eMA9v8CzCbIvTiwHUazQ4yHh/8D6viff9xDP9zg==", null, false, "96ec46b3-a6d5-4ace-99f2-23d470afe1bf", false, "petarkarapetrov@gmail.com" });

            migrationBuilder.InsertData(
                table: "Vinar",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "VinarId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "VinarId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3,
                column: "VinarId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Wines_VinarId",
                table: "Wines",
                column: "VinarId");

            migrationBuilder.CreateIndex(
                name: "IX_Vinar_UserId",
                table: "Vinar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Vinar_VinarId",
                table: "Wines",
                column: "VinarId",
                principalTable: "Vinar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
