using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTickets.Migrations
{
    public partial class AddCityProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cinemas",
                type: "nvarchar(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ShowID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ShowID");
        }
    }
}
