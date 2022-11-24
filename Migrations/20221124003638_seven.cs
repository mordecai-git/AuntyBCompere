using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuntyBCompere.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Booking_BookingId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_BookingId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Service");

            migrationBuilder.CreateTable(
                name: "BookingService",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingService", x => new { x.BookingsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_BookingService_Booking_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingService_Service_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingService_ServicesId",
                table: "BookingService",
                column: "ServicesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingService");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_BookingId",
                table: "Service",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Booking_BookingId",
                table: "Service",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }
    }
}
