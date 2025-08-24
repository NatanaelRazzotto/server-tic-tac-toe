using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_tic_tac_toe.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeOfPlayToMoves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Moves");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfPlay",
                table: "Moves",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfPlay",
                table: "Moves");

            migrationBuilder.AddColumn<char>(
                name: "Symbol",
                table: "Moves",
                type: "character(1)",
                nullable: false,
                defaultValue: '\0');
        }
    }
}
