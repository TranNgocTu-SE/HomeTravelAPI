using System;
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
                name: "FK_Bookings_Tourists_TouristId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Tourists_TouristId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStays_Owners_OwnerId",
                table: "HomeStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AppUser_AppUserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_AppUser_AppUserId",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists");

            migrationBuilder.DropIndex(
                name: "IX_Tourists_AppUserId",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AppUserId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "Tourists");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Owners");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Tourists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PriceEarlyBook",
                table: "Rooms",
                newName: "NumberOfPeople");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Rooms",
                newName: "NumberOfBeds");

            migrationBuilder.RenameColumn(
                name: "PolicyDescription",
                table: "Policy",
                newName: "Transportation");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Owners",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Policy",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Accessablility",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Business",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Common",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connectivity",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodAndDrink",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsideRoom",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NearbyAmenities",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SportsAndRecreation",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingsToDo",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalCapacity",
                table: "HomeStays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "HomeStays",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acreage",
                table: "HomeStays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "FeedBacks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "FeedBacks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FeedBackDate",
                table: "FeedBacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tourists_TouristId",
                table: "Bookings",
                column: "TouristId",
                principalTable: "Tourists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Tourists_TouristId",
                table: "FeedBacks",
                column: "TouristId",
                principalTable: "Tourists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStays_Owners_OwnerId",
                table: "HomeStays",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AppUser_Id",
                table: "Owners",
                column: "Id",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_AppUser_Id",
                table: "Tourists",
                column: "Id",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Owners_OwnerId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Tourists_TouristId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tourists_TouristId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Tourists_TouristId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStays_Owners_OwnerId",
                table: "HomeStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AppUser_Id",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_AppUser_Id",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_OwnerId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_TouristId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Accessablility",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Business",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Common",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Connectivity",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "FoodAndDrink",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "InsideRoom",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "NearbyAmenities",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "SportsAndRecreation",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "ThingsToDo",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Acreage",
                table: "HomeStays");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tourists",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "Rooms",
                newName: "PriceEarlyBook");

            migrationBuilder.RenameColumn(
                name: "NumberOfBeds",
                table: "Rooms",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "Transportation",
                table: "Policy",
                newName: "PolicyDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "Tourists",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Policy",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCapacity",
                table: "HomeStays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "HomeStays",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "FeedBacks",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "FeedBacks",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FeedBackDate",
                table: "FeedBacks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourists",
                table: "Tourists",
                column: "TouristId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourists_AppUserId",
                table: "Tourists",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AppUserId",
                table: "Owners",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tourists_TouristId",
                table: "Bookings",
                column: "TouristId",
                principalTable: "Tourists",
                principalColumn: "TouristId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Tourists_TouristId",
                table: "FeedBacks",
                column: "TouristId",
                principalTable: "Tourists",
                principalColumn: "TouristId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeStays_Owners_OwnerId",
                table: "HomeStays",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AppUser_AppUserId",
                table: "Owners",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_AppUser_AppUserId",
                table: "Tourists",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
