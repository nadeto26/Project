using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Migrations
{
    public partial class Vinar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Vinar_VinarId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "VinarId",
                table: "Wines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e58d6495-4404-4413-9273-0ed0eda9e2c6", "AQAAAAEAACcQAAAAEH8IRnYnYMHwrN5S99jFGf8Qjk2DkBIveetJDK0tVYOSwzHF2Zl6hD+WNqFy4Wz9Eg==", "5d48f711-7a91-46ea-b4b8-9df15e89698f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65be7171-623d-4366-b695-0e697738d76b", "AQAAAAEAACcQAAAAEKfKiM72YAKpWfoR3meKA8UCNi4fXnAvpPPemdqO4gqMPNv/g90od4+bIWP8YsS1Lw==", "d7c71e73-2cf0-4cbb-9f29-dcfc945bb32f" });

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "VinarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 2,
                column: "VinarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 3,
                column: "VinarId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Vinar_VinarId",
                table: "Wines",
                column: "VinarId",
                principalTable: "Vinar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Vinar_VinarId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "VinarId",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bff22ff4-42e7-4c82-9edf-5b4d5dd33dfb", "AQAAAAEAACcQAAAAEH62fJwgTh46jG+nPeW/Kf8oSIB8KlpjYpaImTqZBTDV+3pDJINcXcL1Q8YjTNRfZg==", "508560ff-7460-4c38-bf32-6c1ec719ddae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e84e618-cb84-4674-9079-2b510582fcc3", "AQAAAAEAACcQAAAAEO9iNHugRumEIT0twhhVTyBMPjKVVTJtGBU92Lc6BzR8zK4arB9iNFUGwcn9ybu1Zw==", "a3b396f2-e504-4b0b-b2df-be1438327f8e" });

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
