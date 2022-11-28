using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuntyBCompere.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testimonial_Service_ServiceId",
                table: "Testimonial");

            migrationBuilder.DropIndex(
                name: "IX_Testimonial_ServiceId",
                table: "Testimonial");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Testimonial");

            migrationBuilder.CreateTable(
                name: "TestimonialService",
                columns: table => new
                {
                    TestimonialId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialService", x => new { x.TestimonialId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_TestimonialService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestimonialService_Testimonial_TestimonialId",
                        column: x => x.TestimonialId,
                        principalTable: "Testimonial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialService_ServiceId",
                table: "TestimonialService",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestimonialService");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Testimonial",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_ServiceId",
                table: "Testimonial",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonial_Service_ServiceId",
                table: "Testimonial",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
