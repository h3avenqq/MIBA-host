using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIBA.Migrations
{
    public partial class StudyIdInFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudyId",
                table: "Feedbacks",
                column: "StudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Studies_StudyId",
                table: "Feedbacks",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Studies_StudyId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_StudyId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "StudyId",
                table: "Feedbacks");
        }
    }
}
