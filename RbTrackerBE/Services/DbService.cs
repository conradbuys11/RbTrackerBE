using RbTrackerBE.DatabaseContext;
using RbTrackerBE.DTOs;
using RbTrackerBE.Models;

namespace RbTrackerBE.Services
{
    public class DbService : IDbService
    {
        private readonly AppDbContext _context;
        public DbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game> GameDtoConversion(GameDto dto)
        {
            var awayTeam = await _context.TeamsInYears.FindAsync(dto.AwayTeamId);
            var homeTeam = await _context.TeamsInYears.FindAsync(dto.HomeTeamId);
            if (awayTeam is null)
            {
                throw new Exception("Away team not found from id.");
            }
            if (homeTeam is null)
            {
                throw new Exception("Home team not found from id.");
            }
            return new Game()
            {
                Id = dto.Id,
                GameType = dto.GameType,
                WeekId = dto.WeekId,
                AwayTeamId = dto.AwayTeamId,
                AwayTeam = awayTeam,
                HomeTeamId = dto.HomeTeamId,
                HomeTeam = homeTeam,
                AwayTeamScore = dto.AwayTeamScore,
                HomeTeamScore = dto.HomeTeamScore,
            };
        }

        public async Task<TeamInYear> TeamInYearDtoConversion(TeamInYearDto dto)
        {
            var team = await _context.Teams.FindAsync(dto.TeamId);
            var byeWeek = await _context.Weeks.FindAsync(dto.ByeId);
            if (team is null)
            {
                throw new Exception("Team not found from id.");
            }
            return new TeamInYear()
            {
                Id = dto.Id,
                TeamId = dto.TeamId,
                Team = team,
                YearId = dto.YearId,
                OfRating = dto.OfRating,
                DfRating = dto.DfRating,
                Wins = dto.Wins,
                Losses = dto.Losses,
                Ties = dto.Ties,
                LikelyWins = dto.LikelyWins,
                LikelyLosses = dto.LikelyLosses,
                LikelyTies = dto.LikelyTies,
                ByeId = dto.ByeId,
                Bye = byeWeek
            };
        }

        public async Task<Week> WeekDtoConversion(WeekDto dto)
        {
            var year = await _context.Years.FindAsync(dto.YearId);
            if (year is null) { throw new Exception("Year not found from id."); }
            return new Week()
            {
                Id = dto.Id,
                WeekNo = dto.WeekNo,
                YearId = dto.YearId,
                Year = year
            };
        }
    }
}
