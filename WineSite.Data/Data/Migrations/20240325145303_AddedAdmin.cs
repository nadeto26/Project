using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f80f1e7d-603a-4689-88d1-7a4a0a8508dd", "AQAAAAEAACcQAAAAEBeBCVP0RyN8vGT3qcRJ9RPRswuuy0Waj0Te86KNw0pTIdU5ZiVtsa7QDFwQVFTW5g==", "1a9676be-f551-45d5-914c-8fb6a5954350" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a54da83-7620-477f-962b-8013f529bf06", "AQAAAAEAACcQAAAAEDQ3RlWI72tGZx30IzVlyQLvTbv4FWbdXGPAeGYARcx/bLTiqvYh9feN+k2U2PMXUg==", "abf489ba-9ce7-4531-ae94-c78d939c9da3" });
        }
    }
}
