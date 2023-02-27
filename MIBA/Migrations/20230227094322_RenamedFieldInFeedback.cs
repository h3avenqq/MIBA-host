using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIBA.Migrations
{
    public partial class RenamedFieldInFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Studies_StudyId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "StudyId",
                table: "Feedbacks",
                newName: "StudiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_StudyId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_StudiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Studies_StudiesId",
                table: "Feedbacks",
                column: "StudiesId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Studies_StudiesId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "StudiesId",
                table: "Feedbacks",
                newName: "StudyId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_StudiesId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_StudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Studies_StudyId",
                table: "Feedbacks",
                column: "StudyId",
                principalTable: "Studies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
