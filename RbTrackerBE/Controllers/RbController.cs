using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RbTrackerBE.DatabaseContext;
using RbTrackerBE.Models;

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

        public RbController(AppDbContext context)
        {
            _context = context;
        }

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
            dbGame.Week = game.Week;
            dbGame.TeamOne = game.TeamOne;
            dbGame.TeamTwo = game.TeamTwo;
            dbGame.TeamOneScore = game.TeamOneScore;
            dbGame.TeamTwoScore = game.TeamTwoScore;
            dbGame.IsTie = game.IsTie;
            dbGame.LikelyWinner = game.LikelyWinner;
            dbGame.Winner = game.Winner;
            dbGame.Loser = game.Loser;

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

        //
        // TeamsInYears
        //

        [HttpGet("teamsinyears")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> GetTeamsInYears()
        {
            var teamsInYears = await _context.TeamsInYears.ToListAsync();
            return teamsInYears;
        }

        [HttpGet("teamsinyears/{id}")]
        public async Task<ActionResult<TeamInYear>> GetTeamInYear(int id)
        {
            var teamInYear = await _context.TeamsInYears.FindAsync(id);
            if (teamInYear is null)
            {
                return NotFound();
            }
            return teamInYear;
        }

        [HttpPost("teamsinyears")]
        public async Task<ActionResult<TeamInYear>> PostTeamInYear(TeamInYear team)
        {
            _context.TeamsInYears.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamInYear", new { id = team.Id }, team);
        }

        [HttpPut("teaminyears/{id}")]
        public async Task<ActionResult<TeamInYear>> PutTeamInYear(int id, TeamInYear team)
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

            dbTeam.Team = team.Team;
            dbTeam.Year = team.Year;
            dbTeam.OfRating = team.OfRating;
            dbTeam.DfRating = team.DfRating;
            dbTeam.AvRating = team.AvRating;
            dbTeam.Wins = team.Wins;
            dbTeam.Losses = team.Losses;
            dbTeam.Ties = team.Ties;
            dbTeam.Record = team.Record;
            dbTeam.LikelyWins = team.LikelyWins;
            dbTeam.LikelyLosses = team.LikelyLosses;
            dbTeam.LikelyTies = team.LikelyTies;
            dbTeam.LikelyRecord = team.LikelyRecord;

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
            dbWeek.Year = week.Year;

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


    }
}
