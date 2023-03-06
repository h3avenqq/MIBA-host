using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIBA.Migrations
{
    public partial class CourseRecs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseRecomendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRecomendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRecomendations_Studies_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseRecomendations_CourseId",
                table: "CourseRecomendations",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRecomendations");
        }
    }
}
