using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
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

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "FeedBacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId");

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
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageHomes_HomeStays_HomeStayId",
                table: "ImageHomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HomeStays_HomeStayId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
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

            migrationBuilder.AlterColumn<int>(
                name: "HomeStayId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
