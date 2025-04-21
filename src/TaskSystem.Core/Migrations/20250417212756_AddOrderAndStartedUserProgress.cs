using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAndStartedUserProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "task_order",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "progress_endedAt",
                table: "ChallengeUserProgressEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "progress_startedAt",
                table: "ChallengeUserProgressEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "task_order",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "progress_endedAt",
                table: "ChallengeUserProgressEntity");

            migrationBuilder.DropColumn(
                name: "progress_startedAt",
                table: "ChallengeUserProgressEntity");
        }
    }
}
