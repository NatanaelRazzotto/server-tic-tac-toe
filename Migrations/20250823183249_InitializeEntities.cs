using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_tic_tac_toe.Migrations
{
    /// <inheritdoc />
    public partial class InitializeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Closing = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMatches_Users_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameMatches_Users_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssociatedMatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsiblePlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionColumn = table.Column<int>(type: "integer", nullable: false),
                    PositionRow = table.Column<int>(type: "integer", nullable: false),
                    Symbol = table.Column<char>(type: "character(1)", nullable: false),
                    MovementTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_GameMatches_AssociatedMatchId",
                        column: x => x.AssociatedMatchId,
                        principalTable: "GameMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Users_ResponsiblePlayerId",
                        column: x => x.ResponsiblePlayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMatches_FirstPlayerId",
                table: "GameMatches",
                column: "FirstPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMatches_SecondPlayerId",
                table: "GameMatches",
                column: "SecondPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_AssociatedMatchId",
                table: "Moves",
                column: "AssociatedMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ResponsiblePlayerId",
                table: "Moves",
                column: "ResponsiblePlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "GameMatches");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
