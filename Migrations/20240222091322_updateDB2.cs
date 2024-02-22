using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_HomeStayId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HomeStayId",
                table: "Services",
                column: "HomeStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_HomeStayId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_HomeStayId",
                table: "Services",
                column: "HomeStayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
