using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ba76bbf-054f-4c65-b990-a6a382e8b7e2", "AQAAAAEAACcQAAAAEKqL0wiOZRiwBQfO3MrZ/iq6kAvmr69ij/VN5ynbXfm90sXuXeuMHuUADME1p04q0w==", "d02010a2-039e-4fe7-b09b-970fd52e0c4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdea0e0e-7607-4b9d-94bc-9cc02551494f", "AQAAAAEAACcQAAAAEITt8CuuVqePpWE8R6EvSGfoCNnTbLBg1g5dwFlcngFnBIEIfkD7v2bJfeMVfPYk0g==", "91960877-0831-4967-87d3-1227853cdcd6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f8975f8-f208-451c-bf59-1259886aebdb", "AQAAAAEAACcQAAAAEKmwfs8iig3uCy00A0tvtp+FLJnJmL1sJ3lduhAFVTUv691RtwjyJEeyPhfvXaNPBA==", "b2f9261c-1a52-4410-9e41-1e4d31772205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859ddad4-34cf-4170-b10c-87984d767103", "AQAAAAEAACcQAAAAEB7EXlsnJjmqADF4285HzJ+MHF90k8ac2GlxuszedWIxmjRa7AfpRF1C6D2uesH0Mg==", "c1d5d4bd-9f0a-476c-ab7a-3105c3f37245" });
        }
    }
}
