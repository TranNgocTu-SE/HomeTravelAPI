using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeStayService_HomeStays_HomeStayId",
                table: "HomeStayService");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStayService_HomeStays_HomeStaysHomeStayId",
                table: "HomeStayService");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStayService_Services_ServiceId",
                table: "HomeStayService");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStayService_Services_ServicesServiceId",
                table: "HomeStayService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeStayService",
                table: "HomeStayService");

            migrationBuilder.DropIndex(
                name: "IX_HomeStayService_HomeStayId",
                table: "HomeStayService");

            migrationBuilder.DropIndex(
                name: "IX_HomeStayService_ServiceId",
                table: "HomeStayService");

            migrationBuilder.DropColumn(
                name: "HomeStayId",
                table: "HomeStayService");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "HomeStayService");

            migrationBuilder.RenameTable(
                name: "HomeStayService",
                newName: "HomeStay_Service");

            migrationBuilder.RenameIndex(
                name: "IX_HomeStayService_ServicesServiceId",
                table: "HomeStay_Service",
                newName: "IX_HomeStay_Service_ServicesServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeStay_Service",
                table: "HomeStay_Service",
                columns: new[] { "HomeStaysHomeStayId", "ServicesServiceId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_HomeStays_HomeStaysHomeStayId",
                table: "HomeStay_Service");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStay_Service_Services_ServicesServiceId",
                table: "HomeStay_Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeStay_Service",
                table: "HomeStay_Service");

            migrationBuilder.RenameTable(
                name: "HomeStay_Service",
                newName: "HomeStayService");

            migrationBuilder.RenameIndex(
                name: "IX_HomeStay_Service_ServicesServiceId",
                table: "HomeStayService",
                newName: "IX_HomeStayService_ServicesServiceId");

            migrationBuilder.AddColumn<int>(
                name: "HomeStayId",
                table: "HomeStayService",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "HomeStayService",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeStayService",
                table: "HomeStayService",
                columns: new[] { "HomeStaysHomeStayId", "ServicesServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_HomeStayService_HomeStayId",
                table: "HomeStayService",
                column: "HomeStayId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeStayService_ServiceId",
                table: "HomeStayService",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStayService_HomeStays_HomeStayId",
                table: "HomeStayService",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStayService_HomeStays_HomeStaysHomeStayId",
                table: "HomeStayService",
                column: "HomeStaysHomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStayService_Services_ServiceId",
                table: "HomeStayService",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStayService_Services_ServicesServiceId",
                table: "HomeStayService",
                column: "ServicesServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
