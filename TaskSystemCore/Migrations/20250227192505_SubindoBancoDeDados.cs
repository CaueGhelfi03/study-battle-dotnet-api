using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.core.Migrations
{
    /// <inheritdoc />
    public partial class SubindoBancoDeDados : Migration
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
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
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
                    table.PrimaryKey("PK_Tasks", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_Tasks_Challenge_challenge_id",
                        column: x => x.challenge_id,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_challenge_id",
                table: "Tasks",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
