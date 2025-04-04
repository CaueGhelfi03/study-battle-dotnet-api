using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "user_createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Score",
                newName: "score_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Challenge",
                newName: "challenge_id");

            migrationBuilder.AlterColumn<string>(
                name: "task_description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "task_complexity",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "task_lastCompletedAt",
                table: "Task",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Score",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "score_points",
                table: "Score",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserChallengeProgress",
                columns: table => new
                {
                    progress_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    streak_count = table.Column<int>(type: "int", nullable: false),
                    last_active_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    progress_total_score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChallengeProgress", x => x.progress_id);
                    table.ForeignKey(
                        name: "FK_UserChallengeProgress_Challenge_user_id",
                        column: x => x.user_id,
                        principalTable: "Challenge",
                        principalColumn: "challenge_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChallengeProgress_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Score_UserId",
                table: "Score",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeProgress_user_id",
                table: "UserChallengeProgress",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_User_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "User",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_User_UserId",
                table: "Score");

            migrationBuilder.DropTable(
                name: "UserChallengeProgress");

            migrationBuilder.DropIndex(
                name: "IX_Score_UserId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "task_complexity",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "task_lastCompletedAt",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "score_points",
                table: "Score");

            migrationBuilder.RenameColumn(
                name: "user_createdAt",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "score_id",
                table: "Score",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "challenge_id",
                table: "Challenge",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "task_description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
