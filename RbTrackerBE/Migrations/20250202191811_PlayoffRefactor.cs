using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class PlayoffRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiyInPlayoffPictures");

            migrationBuilder.DropTable(
                name: "PlayoffPictures");

            migrationBuilder.CreateTable(
                name: "PlayoffStandings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeekId = table.Column<int>(type: "integer", nullable: false),
                    TeamInYearId = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    Seed = table.Column<int>(type: "integer", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayoffStandings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayoffStandings_TeamsInYears_TeamInYearId",
                        column: x => x.TeamInYearId,
                        principalTable: "TeamsInYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayoffStandings_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayoffStandings_TeamInYearId",
                table: "PlayoffStandings",
                column: "TeamInYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayoffStandings_WeekId",
                table: "PlayoffStandings",
                column: "WeekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayoffStandings");

            migrationBuilder.CreateTable(
                name: "PlayoffPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeekId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayoffPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayoffPictures_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiyInPlayoffPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayoffPictureId = table.Column<int>(type: "integer", nullable: false),
                    TeamInYearId = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false),
                    Seed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiyInPlayoffPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiyInPlayoffPictures_PlayoffPictures_PlayoffPictureId",
                        column: x => x.PlayoffPictureId,
                        principalTable: "PlayoffPictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiyInPlayoffPictures_TeamsInYears_TeamInYearId",
                        column: x => x.TeamInYearId,
                        principalTable: "TeamsInYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayoffPictures_WeekId",
                table: "PlayoffPictures",
                column: "WeekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiyInPlayoffPictures_PlayoffPictureId",
                table: "TiyInPlayoffPictures",
                column: "PlayoffPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_TiyInPlayoffPictures_TeamInYearId",
                table: "TiyInPlayoffPictures",
                column: "TeamInYearId");
        }
    }
}
