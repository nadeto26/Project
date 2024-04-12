using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Web.Migrations
{
    public partial class RemoveAdminModelClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b77deae3-2179-493d-a097-a7e2f8c40d9c", "AQAAAAEAACcQAAAAEIlUXwliHJru9M8GCDDLQ1HnFAke6To699kioD1XsQCBC3D9Jzm5CC6gRVFy9cOQkg==", "99db13a2-ade9-4027-bc5f-b7bfd4af89ce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c5dd852-4692-4653-92cb-3683d013fd37", "AQAAAAEAACcQAAAAECmOEpWqlgkQ1qFbNdJfeSTg9MkwO0HYp9dO1ut1aCqJ7FhB1+yyodYzkedEpP1fVQ==", "8134e338-ee08-4e31-8c31-19792980542b" });
        }
    }
}
