using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Challenge_ChallengeEntityId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ChallengeEntityId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ChallengeEntityId",
                table: "User");

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

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeEntityUserEntity_UsersId",
                table: "ChallengeEntityUserEntity",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeEntityUserEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "ChallengeEntityId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ChallengeEntityId",
                table: "User",
                column: "ChallengeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Challenge_ChallengeEntityId",
                table: "User",
                column: "ChallengeEntityId",
                principalTable: "Challenge",
                principalColumn: "challenge_id");
        }
    }
}
