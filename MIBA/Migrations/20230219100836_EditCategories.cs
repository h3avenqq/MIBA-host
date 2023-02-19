using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIBA.Migrations
{
    public partial class EditCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "StudyCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "StudyCategories");
        }
    }
}
