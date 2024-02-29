using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Bookings_BookingId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BookingId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_BookingId",
                table: "Services",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Bookings_BookingId",
                table: "Services",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }
    }
}
