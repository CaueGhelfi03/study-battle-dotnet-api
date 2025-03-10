using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    challenge_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    challenge_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    challenge_duration = table.Column<int>(type: "int", nullable: false),
                    challenge_createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    challenge_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    challenge_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    challenge_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChallengeEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_User_Challenge_ChallengeEntityId",
                        column: x => x.ChallengeEntityId,
                        principalTable: "Challenge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    task_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    task_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    task_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_Task_Challenge_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_challenge_id",
                table: "Task",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_user_id",
                table: "Task",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_ChallengeEntityId",
                table: "User",
                column: "ChallengeEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Challenge");
        }
    }
}
