using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuntyBCompere.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Service_ServiceId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ServiceId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStandard",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Test",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsStandard",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ServiceId",
                table: "Booking",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Service_ServiceId",
                table: "Booking",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
