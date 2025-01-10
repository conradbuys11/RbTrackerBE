using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class FKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikelyWinner",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Loser",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "TeamsInYears",
                newName: "Record");

            migrationBuilder.AddColumn<int>(
                name: "LikelyLosses",
                table: "TeamsInYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LikelyRecord",
                table: "TeamsInYears",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LikelyTies",
                table: "TeamsInYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikelyWins",
                table: "TeamsInYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikelyWinnerId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoserId",
                table: "Games",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Games",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_LikelyWinnerId",
                table: "Games",
                column: "LikelyWinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LoserId",
                table: "Games",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerId",
                table: "Games",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_LikelyWinnerId",
                table: "Games",
                column: "LikelyWinnerId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_LoserId",
                table: "Games",
                column: "LoserId",
                principalTable: "TeamsInYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "TeamsInYears",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_LikelyWinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_LoserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_WinnerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LikelyWinnerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LoserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WinnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LikelyLosses",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "LikelyRecord",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "LikelyTies",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "LikelyWins",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "LikelyWinnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LoserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Record",
                table: "TeamsInYears",
                newName: "Rating");

            migrationBuilder.AddColumn<string>(
                name: "LikelyWinner",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Loser",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Games",
                type: "text",
                nullable: true);
        }
    }
}
