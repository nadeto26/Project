using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class WineQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "WineBuyers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Wine quantity");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WineBuyers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f72eee4f-32a7-4dd5-8286-19955f66bf96", "AQAAAAEAACcQAAAAEO4pkuixJNEAuI20oIObTnvbZ1SqF4ECmCcYeVj+Qasn9/kI65fYB8tT7+pntONqvw==", "47230937-4a13-4eb9-b57b-f6b03880ca43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "575a6df4-352c-4721-a938-f17f3c5bf765", "AQAAAAEAACcQAAAAEJQ63E8lhoCRt1maOus9JfAPDnXw1xglU4f7yLKICt2rL9yu18j+WFluSRBmgaTLuw==", "e617f254-83df-463a-8b97-a4ad6867de96" });
        }
    }
}
