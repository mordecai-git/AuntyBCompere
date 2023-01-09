using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuntyBCompere.Migrations
{
    public partial class thirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Test",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
