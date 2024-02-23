using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
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

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "ImageHomes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "HomeStays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "HomeStays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppUser");

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "ImageHomes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_HomeStays_HomeStayId",
                table: "Services",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");
        }
    }
}
