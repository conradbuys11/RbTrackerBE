using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class PlayoffPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayoffPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeekId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayoffPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayoffPicture_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiyInPlayoffPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayoffPictureId = table.Column<int>(type: "integer", nullable: false),
                    TeamInYearId = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    Seed = table.Column<int>(type: "integer", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiyInPlayoffPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiyInPlayoffPicture_PlayoffPicture_PlayoffPictureId",
                        column: x => x.PlayoffPictureId,
                        principalTable: "PlayoffPicture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiyInPlayoffPicture_TeamsInYears_TeamInYearId",
                        column: x => x.TeamInYearId,
                        principalTable: "TeamsInYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayoffPicture_WeekId",
                table: "PlayoffPicture",
                column: "WeekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiyInPlayoffPicture_PlayoffPictureId",
                table: "TiyInPlayoffPicture",
                column: "PlayoffPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_TiyInPlayoffPicture_TeamInYearId",
                table: "TiyInPlayoffPicture",
                column: "TeamInYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiyInPlayoffPicture");

            migrationBuilder.DropTable(
                name: "PlayoffPicture");
        }
    }
}
