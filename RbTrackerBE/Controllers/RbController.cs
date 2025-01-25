using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RbTrackerBE.DatabaseContext;
using RbTrackerBE.DTOs;
using RbTrackerBE.Models;
using RbTrackerBE.Services;

// https://www.c-sharpcorner.com/article/building-a-powerful-asp-net-core-web-api-with-postgresql/ helps a lot
// though it also just uses a lot of the code from the udemy tutorial?
// https://www.pragimtech.com/blog/blazor/put-in-asp.net-core-rest-api/

namespace RbTrackerBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RbController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDbService _dbService;

        public RbController(AppDbContext context, IDbService dbService)
        {
            _context = context;
            _dbService = dbService;
        }

        #region Games
        //
        // Games
        //

        [HttpGet("games")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        [HttpGet("games/{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            return game;
        }

        [HttpPost("games")]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("games/{id}")]
        public async Task<ActionResult<Game>> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            var dbGame = await _context.Games.FindAsync(game.Id);
            if (dbGame is null)
            {
                return NotFound();
            }

            dbGame.GameType = game.GameType;
            dbGame.WeekId = game.WeekId;
            dbGame.AwayTeamId = game.AwayTeamId;
            dbGame.HomeTeamId = game.HomeTeamId;
            dbGame.AwayTeamScore = game.AwayTeamScore;
            dbGame.HomeTeamScore = game.HomeTeamScore;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

            return NoContent();
        }
        #endregion

        #region Teams
        //
        // Teams
        //

        [HttpGet("teams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams;
        }

        [HttpGet("teams/{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team is null)
            {
                return NotFound();
            }
            return team;
        }

        [HttpPost("teams")]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        [HttpPut("teams/{id}")]
        public async Task<ActionResult<Team>> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            var dbTeam = await _context.Teams.FindAsync(id);
            if (dbTeam is null)
            {
                return NotFound();
            }

            // update all attributes (could probably be done in a service or something)
            dbTeam.Code = team.Code;
            dbTeam.Location = team.Location;
            dbTeam.Name = team.Name;
            dbTeam.Conference = team.Conference;
            dbTeam.Division = team.Division;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

            return NoContent();
        }
        #endregion

        //
        // TeamsInYears
        //

        [HttpGet("teamsinyears")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> GetTeamsInYears()
        {
            var teamsInYears = await _context.TeamsInYears.Include(team => team.Team).ToListAsync();
            return teamsInYears;
        }

        [HttpGet("teamsinyears/{id}")]
        public async Task<ActionResult<TeamInYear>> GetTeamInYear(int id)
        {
            var teamInYear = await _context.TeamsInYears.Include(team => team.Team).FirstAsync(team => team.Id == id);
            if (teamInYear is null)
            {
                return NotFound();
            }
            return teamInYear;
        }

        [HttpGet("teamsinyears/many/{yearId}")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> GetTeamsInSpecificYear(int yearId)
        {
            bool hasYear = await _context.Years.AnyAsync(year => year.Id == yearId);
            if (!hasYear)
            {
                return BadRequest();
            }

            var teamsInYear = await _context.TeamsInYears.Include(team => team.Team).Where(team => team.YearId == yearId).ToListAsync();
            if (teamsInYear is null)
            {
                return NotFound();
            }

            return teamsInYear;
        }

        [HttpPost("teamsinyears")]
        public async Task<ActionResult<TeamInYear>> PostTeamInYear(TeamInYearDto team)
        {
            TeamInYear teamInYear = await _dbService.TeamInYearDtoConversion(team);
            _context.TeamsInYears.Add(teamInYear);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamInYear", new { id = team.Id }, team);
        }

        [HttpPost("teamsinyears/many")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> PostTeamInYears(IEnumerable<TeamInYearDto> teams)
        {
            foreach (var team in teams)
            {
                TeamInYear teamInYear = await _dbService.TeamInYearDtoConversion(team);
                _context.TeamsInYears.Add(teamInYear);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamsInSpecificYear", new { yearId = teams.First().YearId }, teams);
        }

        [HttpPut("teaminyears/{id}")]
        public async Task<ActionResult<TeamInYear>> PutTeamInYear(int id, TeamInYearDto team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            var dbTeam = await _context.TeamsInYears.FindAsync(id);
            if (dbTeam is null)
            {
                return NotFound();
            }

            dbTeam.TeamId = team.TeamId;
            dbTeam.YearId = team.YearId;
            dbTeam.OfRating = team.OfRating;
            dbTeam.DfRating = team.DfRating;
            dbTeam.Wins = team.Wins;
            dbTeam.Losses = team.Losses;
            dbTeam.Ties = team.Ties;
            dbTeam.LikelyWins = team.LikelyWins;
            dbTeam.LikelyLosses = team.LikelyLosses;
            dbTeam.LikelyTies = team.LikelyTies;
            dbTeam.ByeId = team.ByeId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

            return NoContent();
        }

        //
        // Weeks
        //

        [HttpGet("weeks")]
        public async Task<ActionResult<IEnumerable<Week>>> GetWeeks()
        {
            var weeks = await _context.Weeks.ToListAsync();
            return weeks;
        }

        [HttpGet("weeks/{id}")]
        public async Task<ActionResult<Week>> GetWeek(int id)
        {
            var week = await _context.Weeks.FindAsync(id);
            if (week is null)
            {
                return NotFound();
            }
            return week;
        }

        [HttpPost("weeks")]
        public async Task<ActionResult<Week>> PostWeek(Week week)
        {
            _context.Weeks.Add(week);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeek", new { id = week.Id }, week);
        }

        [HttpPut("weeks/{id}")]
        public async Task<ActionResult<Week>> PutWeek(int id, Week week)
        {
            if (id != week.Id)
            {
                return BadRequest();
            }

            var dbWeek = await _context.Weeks.FindAsync(id);
            if (dbWeek is null)
            {
                return NotFound();
            }

            dbWeek.WeekNo = week.WeekNo;
            dbWeek.YearId = week.YearId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

            return NoContent();
        }

        //
        // Years
        //

        [HttpGet("years")]
        public async Task<ActionResult<IEnumerable<Year>>> GetYears()
        {
            var years = await _context.Years.ToListAsync();
            return years;
        }

        [HttpGet("years/{id}")]
        public async Task<ActionResult<Year>> GetYear(int id)
        {
            var year = await _context.Years.FindAsync(id);
            if (year is null)
            {
                return NotFound();
            }
            return year;
        }

        [HttpPost("years")]
        public async Task<ActionResult<Year>> PostYear(Year year)
        {
            _context.Years.Add(year);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetYear", new { id = year.Id }, year);
        }

        [HttpPut("years/{id}")]
        public async Task<ActionResult<Year>> PutYear(int id, Year year)
        {
            if (id != year.Id)
            {
                return BadRequest();
            }

            var dbYear = await _context.Years.FindAsync(id);
            if (dbYear is null)
            {
                return NotFound();
            }

            // update all attributes (could probably be done in a service or something)
            dbYear.YearNo = year.YearNo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }

            return NoContent();
        }


        //public async Task<ActionResult<Year>> CreateAndPopulateYear(Year year, IEnumerable<TeamInYear> teamsInYear)
        //{

        //}
    }
}
