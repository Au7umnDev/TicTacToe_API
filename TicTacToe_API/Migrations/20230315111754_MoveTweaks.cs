using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe_API.Migrations
{
    /// <inheritdoc />
    public partial class MoveTweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                table: "Moves",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Games_GameId",
                table: "Moves",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Games_GameId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_GameId",
                table: "Moves");
        }
    }
}
