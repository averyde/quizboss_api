using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizBoss_API.Migrations
{
    /// <inheritdoc />
    public partial class Removedinfiniterecursionfrommodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questiones_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questiones_Quizzes_QuizId",
                table: "Questiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questiones",
                table: "Questiones");

            migrationBuilder.RenameTable(
                name: "Questiones",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Questiones_QuizId",
                table: "Questions",
                newName: "IX_Questions_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Questiones");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizId",
                table: "Questiones",
                newName: "IX_Questiones_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questiones",
                table: "Questiones",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questiones_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questiones",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questiones_Quizzes_QuizId",
                table: "Questiones",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
