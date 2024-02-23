using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Owners_OwnerId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Tourists_TouristId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_OwnerId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_TouristId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "AppUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_OwnerId",
                table: "AppUser",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_TouristId",
                table: "AppUser",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Owners_OwnerId",
                table: "AppUser",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Tourists_TouristId",
                table: "AppUser",
                column: "TouristId",
                principalTable: "Tourists",
                principalColumn: "Id");
        }
    }
}
