using Microsoft.EntityFrameworkCore.Migrations;

namespace SEW.Migrations
{
    public partial class WordProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Review",
                newName: "Progress",
                table: "Words");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Progress",
                newName: "Review",
                table: "Words");
        }
    }
}
