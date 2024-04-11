using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class MoreInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoreInformation_Vinar_VinarId",
                table: "MoreInformation");

            migrationBuilder.DropIndex(
                name: "IX_MoreInformation_VinarId",
                table: "MoreInformation");

            migrationBuilder.DropColumn(
                name: "VinarId",
                table: "MoreInformation");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VinarId",
                table: "MoreInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_MoreInformation_VinarId",
                table: "MoreInformation",
                column: "VinarId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoreInformation_Vinar_VinarId",
                table: "MoreInformation",
                column: "VinarId",
                principalTable: "Vinar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
