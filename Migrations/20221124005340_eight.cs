using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuntyBCompere.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_Booking_BookingsId",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_Service_ServicesId",
                table: "BookingService");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "BookingService",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "BookingsId",
                table: "BookingService",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingService_ServicesId",
                table: "BookingService",
                newName: "IX_BookingService_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_Booking_BookingId",
                table: "BookingService",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_Service_ServiceId",
                table: "BookingService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_Booking_BookingId",
                table: "BookingService");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingService_Service_ServiceId",
                table: "BookingService");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "BookingService",
                newName: "ServicesId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "BookingService",
                newName: "BookingsId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingService_ServiceId",
                table: "BookingService",
                newName: "IX_BookingService_ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_Booking_BookingsId",
                table: "BookingService",
                column: "BookingsId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingService_Service_ServicesId",
                table: "BookingService",
                column: "ServicesId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
