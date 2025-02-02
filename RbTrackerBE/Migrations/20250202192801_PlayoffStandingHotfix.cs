using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class PlayoffStandingHotfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Change",
                table: "PlayoffStandings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change",
                table: "PlayoffStandings");
        }
    }
}
