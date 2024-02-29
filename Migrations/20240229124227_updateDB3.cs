using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_HomeStays_HomeStaysHomeStayId",
                table: "HomeStay_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_Services_ServicesServiceId",
                table: "HomeStay_Service");

            migrationBuilder.RenameColumn(
                name: "ServicesServiceId",
                table: "HomeStay_Service",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "HomeStaysHomeStayId",
                table: "HomeStay_Service",
                newName: "HomeStayId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeStay_Service_ServicesServiceId",
                table: "HomeStay_Service",
                newName: "IX_HomeStay_Service_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStay_Service_HomeStays_HomeStayId",
                table: "HomeStay_Service",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStay_Service_Services_ServiceId",
                table: "HomeStay_Service",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_HomeStays_HomeStayId",
                table: "HomeStay_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_Services_ServiceId",
                table: "HomeStay_Service");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "HomeStay_Service",
                newName: "ServicesServiceId");

            migrationBuilder.RenameColumn(
                name: "HomeStayId",
                table: "HomeStay_Service",
                newName: "HomeStaysHomeStayId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeStay_Service_ServiceId",
                table: "HomeStay_Service",
                newName: "IX_HomeStay_Service_ServicesServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStay_Service_HomeStays_HomeStaysHomeStayId",
                table: "HomeStay_Service",
                column: "HomeStaysHomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStay_Service_Services_ServicesServiceId",
                table: "HomeStay_Service",
                column: "ServicesServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
