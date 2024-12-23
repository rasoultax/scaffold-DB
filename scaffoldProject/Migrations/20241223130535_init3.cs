using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scaffoldProject.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "books",
                type: "int",
                nullable: true);
        }
    }
}
