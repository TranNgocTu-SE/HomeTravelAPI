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
            migrationBuilder.CreateTable(
                name: "HomeStay_Service",
                columns: table => new
                {
                    HomeStaysHomeStayId = table.Column<int>(type: "int", nullable: false),
                    ServicesServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStay_Service", x => new { x.HomeStaysHomeStayId, x.ServicesServiceId });
                    table.ForeignKey(
                        name: "FK_HomeStay_Service_HomeStays_HomeStaysHomeStayId",
                        column: x => x.HomeStaysHomeStayId,
                        principalTable: "HomeStays",
                        principalColumn: "HomeStayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeStay_Service_Services_ServicesServiceId",
                        column: x => x.ServicesServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeStay_Service_ServicesServiceId",
                table: "HomeStay_Service",
                column: "ServicesServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeStay_Services",
                columns: table => new
                {
                    HomeStayId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeStay_Services", x => new { x.HomeStayId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_HomeStay_Services_HomeStays_HomeStayId",
                        column: x => x.HomeStayId,
                        principalTable: "HomeStays",
                        principalColumn: "HomeStayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeStay_Services_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeStay_Services_ServiceId",
                table: "HomeStay_Services",
                column: "ServiceId");
        }
    }
}
