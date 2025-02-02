using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RbTrackerBE.Migrations
{
    /// <inheritdoc />
    public partial class TeamInYearSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "TeamsInYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seed",
                table: "TeamsInYears",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "TeamsInYears");

            migrationBuilder.DropColumn(
                name: "Seed",
                table: "TeamsInYears");
        }
    }
}
