using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class FixFkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_LikelyWinnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_LoserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_TeamOneId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_TeamTwoId",
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
                name: "AvRating",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "LikelyRecord",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "Record",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "IsTie",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LikelyWinnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LoserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TeamOneScore",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Games",
                newName: "HomeTeamScore");

            migrationBuilder.RenameColumn(
                name: "TeamTwoScore",
                table: "Games",
                newName: "AwayTeamScore");

            migrationBuilder.RenameColumn(
                name: "TeamTwoId",
                table: "Games",
                newName: "HomeTeamId");

            migrationBuilder.RenameColumn(
                name: "TeamOneId",
                table: "Games",
                newName: "AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TeamTwoId",
                table: "Games",
                newName: "IX_Games_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TeamOneId",
                table: "Games",
                newName: "IX_Games_AwayTeamId");

            migrationBuilder.AddColumn<int>(
                name: "ByeId",
                table: "TeamsInYears",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInYears_ByeId",
                table: "TeamsInYears",
                column: "ByeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInYears_Weeks_ByeId",
                table: "TeamsInYears",
                column: "ByeId",
                principalTable: "Weeks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_AwayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_TeamsInYears_HomeTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInYears_Weeks_ByeId",
                table: "TeamsInYears");

            migrationBuilder.DropIndex(
                name: "IX_TeamsInYears_ByeId",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "ByeId",
                table: "TeamsInYears");

            migrationBuilder.RenameColumn(
                name: "HomeTeamScore",
                table: "Games",
                newName: "WinnerId");

            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "Games",
                newName: "TeamTwoId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamScore",
                table: "Games",
                newName: "TeamTwoScore");

            migrationBuilder.RenameColumn(
                name: "AwayTeamId",
                table: "Games",
                newName: "TeamOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                newName: "IX_Games_TeamTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                newName: "IX_Games_TeamOneId");

            migrationBuilder.AddColumn<float>(
                name: "AvRating",
                table: "TeamsInYears",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "LikelyRecord",
                table: "TeamsInYears",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Record",
                table: "TeamsInYears",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTie",
                table: "Games",
                type: "boolean",
                nullable: true);

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
                name: "TeamOneScore",
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
                name: "FK_Games_TeamsInYears_TeamOneId",
                table: "Games",
                column: "TeamOneId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_TeamTwoId",
                table: "Games",
                column: "TeamTwoId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_TeamsInYears_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "TeamsInYears",
                principalColumn: "Id");
        }
    }
}
