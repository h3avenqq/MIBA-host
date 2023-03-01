using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIBA.Migrations
{
    public partial class AddedPhotoFieldInLectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Lectors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Lectors");
        }
    }
}
