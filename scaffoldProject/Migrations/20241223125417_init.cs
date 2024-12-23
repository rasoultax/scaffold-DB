using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scaffoldProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) { }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_details");

            migrationBuilder.DropTable(
                name: "book_genres");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
