using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineSite.Data.Data.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TicketDeliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Tickets delivery user email");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuentityEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EventId",
                table: "Orders",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TicketDeliveries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "388ff131-5520-49ca-b0ba-99c0d9516214", "AQAAAAEAACcQAAAAEBrNSQRCTP2ClHrs2Ut6kpF9jKsmMX3cUKbgWCM9W0JqnuwDde/vjdzu4L6MdOp3cA==", "960ae7c5-1090-41ba-a3e8-2cc719bd73d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04f44600-50b1-4f94-bcbd-d4c5e538bbf9", "AQAAAAEAACcQAAAAED8AzmDHyKseqxP9en/gXB/WfVm8h1yrs5oLxRXz3r2ZXTSe4gAmskQeBEvHcfQcsA==", "3ab5e156-e219-4718-8139-75b80320529e" });
        }
    }
}
