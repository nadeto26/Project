using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class WineBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventWineBuyers_AspNetUsers_BuyerId",
                table: "EventWineBuyers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventWineBuyers_Wines_WineId",
                table: "EventWineBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers");

            migrationBuilder.RenameTable(
                name: "EventWineBuyers",
                newName: "WineBuyers");

            migrationBuilder.RenameIndex(
                name: "IX_EventWineBuyers_BuyerId",
                table: "WineBuyers",
                newName: "IX_WineBuyers_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WineBuyers",
                table: "WineBuyers",
                columns: new[] { "WineId", "BuyerId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_WineBuyers_AspNetUsers_BuyerId",
                table: "WineBuyers",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WineBuyers_Wines_WineId",
                table: "WineBuyers",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WineBuyers_AspNetUsers_BuyerId",
                table: "WineBuyers");

            migrationBuilder.DropForeignKey(
                name: "FK_WineBuyers_Wines_WineId",
                table: "WineBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WineBuyers",
                table: "WineBuyers");

            migrationBuilder.RenameTable(
                name: "WineBuyers",
                newName: "EventWineBuyers");

            migrationBuilder.RenameIndex(
                name: "IX_WineBuyers_BuyerId",
                table: "EventWineBuyers",
                newName: "IX_EventWineBuyers_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventWineBuyers",
                table: "EventWineBuyers",
                columns: new[] { "WineId", "BuyerId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62621c88-af1d-437a-8162-3b41094a2dba", "AQAAAAEAACcQAAAAEBh4Zv3NN3P5QLJQgZC6srAtKurD4wWxbHbPvvNWjCj7uMsHza5aD9gdHdgsUC0PDQ==", "36b08cd0-feff-48fb-b3df-044e94942aa3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d0bc094-9599-4cc8-925b-04c6789502fb", "AQAAAAEAACcQAAAAEEHNF655nTxLtn+2bGk8ckw1UN5eMA9v8CzCbIvTiwHUazQ4yHh/8D6viff9xDP9zg==", "96ec46b3-a6d5-4ace-99f2-23d470afe1bf" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventWineBuyers_AspNetUsers_BuyerId",
                table: "EventWineBuyers",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventWineBuyers_Wines_WineId",
                table: "EventWineBuyers",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
