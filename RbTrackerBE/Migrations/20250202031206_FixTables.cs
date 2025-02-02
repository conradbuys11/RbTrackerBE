using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayoffPicture_Weeks_WeekId",
                table: "PlayoffPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_TiyInPlayoffPicture_PlayoffPicture_PlayoffPictureId",
                table: "TiyInPlayoffPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_TiyInPlayoffPicture_TeamsInYears_TeamInYearId",
                table: "TiyInPlayoffPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiyInPlayoffPicture",
                table: "TiyInPlayoffPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayoffPicture",
                table: "PlayoffPicture");

            migrationBuilder.RenameTable(
                name: "TiyInPlayoffPicture",
                newName: "TiyInPlayoffPictures");

            migrationBuilder.RenameTable(
                name: "PlayoffPicture",
                newName: "PlayoffPictures");

            migrationBuilder.RenameIndex(
                name: "IX_TiyInPlayoffPicture_TeamInYearId",
                table: "TiyInPlayoffPictures",
                newName: "IX_TiyInPlayoffPictures_TeamInYearId");

            migrationBuilder.RenameIndex(
                name: "IX_TiyInPlayoffPicture_PlayoffPictureId",
                table: "TiyInPlayoffPictures",
                newName: "IX_TiyInPlayoffPictures_PlayoffPictureId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayoffPicture_WeekId",
                table: "PlayoffPictures",
                newName: "IX_PlayoffPictures_WeekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiyInPlayoffPictures",
                table: "TiyInPlayoffPictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayoffPictures",
                table: "PlayoffPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayoffPictures_Weeks_WeekId",
                table: "PlayoffPictures",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiyInPlayoffPictures_PlayoffPictures_PlayoffPictureId",
                table: "TiyInPlayoffPictures",
                column: "PlayoffPictureId",
                principalTable: "PlayoffPictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiyInPlayoffPictures_TeamsInYears_TeamInYearId",
                table: "TiyInPlayoffPictures",
                column: "TeamInYearId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayoffPictures_Weeks_WeekId",
                table: "PlayoffPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_TiyInPlayoffPictures_PlayoffPictures_PlayoffPictureId",
                table: "TiyInPlayoffPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_TiyInPlayoffPictures_TeamsInYears_TeamInYearId",
                table: "TiyInPlayoffPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiyInPlayoffPictures",
                table: "TiyInPlayoffPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayoffPictures",
                table: "PlayoffPictures");

            migrationBuilder.RenameTable(
                name: "TiyInPlayoffPictures",
                newName: "TiyInPlayoffPicture");

            migrationBuilder.RenameTable(
                name: "PlayoffPictures",
                newName: "PlayoffPicture");

            migrationBuilder.RenameIndex(
                name: "IX_TiyInPlayoffPictures_TeamInYearId",
                table: "TiyInPlayoffPicture",
                newName: "IX_TiyInPlayoffPicture_TeamInYearId");

            migrationBuilder.RenameIndex(
                name: "IX_TiyInPlayoffPictures_PlayoffPictureId",
                table: "TiyInPlayoffPicture",
                newName: "IX_TiyInPlayoffPicture_PlayoffPictureId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayoffPictures_WeekId",
                table: "PlayoffPicture",
                newName: "IX_PlayoffPicture_WeekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiyInPlayoffPicture",
                table: "TiyInPlayoffPicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayoffPicture",
                table: "PlayoffPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayoffPicture_Weeks_WeekId",
                table: "PlayoffPicture",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiyInPlayoffPicture_PlayoffPicture_PlayoffPictureId",
                table: "TiyInPlayoffPicture",
                column: "PlayoffPictureId",
                principalTable: "PlayoffPicture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiyInPlayoffPicture_TeamsInYears_TeamInYearId",
                table: "TiyInPlayoffPicture",
                column: "TeamInYearId",
                principalTable: "TeamsInYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
