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
            migrationBuilder.DropColumn(
                name: "CartNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NameOnCart",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOnCart",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
