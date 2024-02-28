using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HomeStays_HomeStayId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StreeName",
                table: "Locations",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "HomeStayId",
                table: "Bookings",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_HomeStayId",
                table: "Bookings",
                newName: "IX_Bookings_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_BookingId",
                table: "Services",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Bookings_BookingId",
                table: "Services",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Bookings_BookingId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BookingId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Locations",
                newName: "StreeName");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Bookings",
                newName: "HomeStayId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                newName: "IX_Bookings_HomeStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HomeStays_HomeStayId",
                table: "Bookings",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
