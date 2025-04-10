using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseWithNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_user_id",
                table: "Task");

            migrationBuilder.DropTable(
                name: "ChallengeEntityUserEntity");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "UserChallengeProgress");

            migrationBuilder.DropIndex(
                name: "IX_Task_user_id",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Task");

            migrationBuilder.CreateTable(
                name: "ChallengeUserProgressEntity",
                columns: table => new
                {
                    progress_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    streak_count = table.Column<int>(type: "int", nullable: false),
                    last_active_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    progress_total_score = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeUserProgressEntity", x => x.progress_id);
                    table.ForeignKey(
                        name: "FK_ChallengeUserProgressEntity_Challenge_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "Challenge",
                        principalColumn: "challenge_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeUserProgressEntity_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskCompletion",
                columns: table => new
                {
                    completion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    completion_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completion_score = table.Column<int>(type: "int", nullable: false),
                    is_validated = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    task_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskCompletion", x => x.completion_id);
                    table.ForeignKey(
                        name: "FK_UserTaskCompletion_Task_task_id",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskCompletion_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeUserProgressEntity_challenge_id",
                table: "ChallengeUserProgressEntity",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeUserProgressEntity_user_id",
                table: "ChallengeUserProgressEntity",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskCompletion_task_id",
                table: "UserTaskCompletion",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskCompletion_user_id",
                table: "UserTaskCompletion",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeUserProgressEntity");

            migrationBuilder.DropTable(
                name: "UserTaskCompletion");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ChallengeEntityUserEntity",
                columns: table => new
                {
                    ChallengesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeEntityUserEntity", x => new { x.ChallengesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChallengeEntityUserEntity_Challenge_ChallengesId",
                        column: x => x.ChallengesId,
                        principalTable: "Challenge",
                        principalColumn: "challenge_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeEntityUserEntity_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ranking_challengeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ranking_createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ranking_updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranking_Challenge_Id",
                        column: x => x.Id,
                        principalTable: "Challenge",
                        principalColumn: "challenge_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    score_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    score_points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.score_id);
                    table.ForeignKey(
                        name: "FK_Score_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserChallengeProgress",
                columns: table => new
                {
                    progress_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    last_active_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    streak_count = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_Task_user_id",
                table: "Task",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeEntityUserEntity_UsersId",
                table: "ChallengeEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_UserId",
                table: "Score",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallengeProgress_user_id",
                table: "UserChallengeProgress",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_user_id",
                table: "Task",
                column: "user_id",
                principalTable: "User",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
