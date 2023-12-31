using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTickets.Migrations
{
    public partial class cinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_CinemaAddresses_CinemaAddressID",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "CinemaAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_CinemaAddressID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "CinemaAddressID",
                table: "Cinemas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaAddressID",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CinemaAddresses",
                columns: table => new
                {
                    CinemaAdressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaAddresses", x => x.CinemaAdressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_CinemaAddressID",
                table: "Cinemas",
                column: "CinemaAddressID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_CinemaAddresses_CinemaAddressID",
                table: "Cinemas",
                column: "CinemaAddressID",
                principalTable: "CinemaAddresses",
                principalColumn: "CinemaAdressID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
