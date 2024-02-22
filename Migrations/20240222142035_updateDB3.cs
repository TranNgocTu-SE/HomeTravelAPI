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
                name: "FK_Rooms_Payment_PaymentId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PaymentId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "HomeStays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeStayId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TouristId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HomeStays_OwnerId",
                table: "HomeStays",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_HomeStayId",
                table: "FeedBacks",
                column: "HomeStayId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_TouristId",
                table: "FeedBacks",
                column: "TouristId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks",
                column: "HomeStayId",
                principalTable: "HomeStays",
                principalColumn: "HomeStayId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_HomeStays_HomeStayId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Tourists_TouristId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeStays_Owners_OwnerId",
                table: "HomeStays");

            migrationBuilder.DropIndex(
                name: "IX_HomeStays_OwnerId",
                table: "HomeStays");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_HomeStayId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_TouristId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "HomeStays");

            migrationBuilder.DropColumn(
                name: "HomeStayId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "TouristId",
                table: "FeedBacks");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PaymentId",
                table: "Rooms",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Payment_PaymentId",
                table: "Rooms",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId");
        }
    }
}
