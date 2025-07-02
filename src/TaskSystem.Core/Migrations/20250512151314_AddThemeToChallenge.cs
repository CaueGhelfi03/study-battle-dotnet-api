using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddThemeToChallenge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "challenge_subject",
                table: "Challenge",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "challenge_subject",
                table: "Challenge");
        }
    }
}
