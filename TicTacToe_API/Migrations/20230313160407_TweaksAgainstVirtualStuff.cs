using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe_API.Migrations
{
    /// <inheritdoc />
    public partial class TweaksAgainstVirtualStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerNumber",
                table: "Moves");

            migrationBuilder.AddColumn<string>(
                name: "Player",
                table: "Moves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentTurn",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player",
                table: "Moves");

            migrationBuilder.AddColumn<int>(
                name: "PlayerNumber",
                table: "Moves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTurn",
                table: "Games",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
