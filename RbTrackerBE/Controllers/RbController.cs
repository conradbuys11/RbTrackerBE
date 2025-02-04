using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RbTrackerBE.DatabaseContext;
using RbTrackerBE.DTOs;
using RbTrackerBE.DTOs.Game;
using RbTrackerBE.DTOs.PlayoffStanding;
using RbTrackerBE.DTOs.Team;
using RbTrackerBE.DTOs.TeamInYear;
using RbTrackerBE.DTOs.Week;
using RbTrackerBE.DTOs.Year;
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

        [HttpPost("games/many")]
        public async Task<ActionResult<IEnumerable<Game>>> PostGames(IEnumerable<GameDto> dtos)
        {
            List<Game> games = [];
            foreach (var dto in dtos)
            {
                Game game = await _dbService.GameDtoConversion(dto);
                games.Add(game);
            }

            _context.Games.AddRange(games);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = games[0].Id }, games);
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

            var teamsInYear = await _context.TeamsInYears
                .Include(team => team.Team)
                .Where(team => team.YearId == yearId).ToListAsync();
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

            team.Id = teamInYear.Id;
            team.TeamName = teamInYear.Team.Name;
            return CreatedAtAction("GetTeamInYear", new { id = team.Id }, team);
        }

        [HttpPost("teamsinyears/many")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> PostTeamInYears(IEnumerable<TeamInYearDto> teams)
        {
            List<TeamInYear> tiys = new List<TeamInYear>();
            foreach (var team in teams)
            {
                TeamInYear teamInYear = await _dbService.TeamInYearDtoConversion(team);
                tiys.Add(teamInYear);
            }
            _context.TeamsInYears.AddRange(tiys);

            await _context.SaveChangesAsync();
            var newDtos = tiys.Select(tiy => new TeamInYearDto()
            {
                Id = tiy.Id,
                TeamId = tiy.TeamId,
                TeamName = tiy.Team.Name,
                YearId = tiy.YearId,
                OfRating = tiy.OfRating,
                DfRating = tiy.DfRating,
                Wins = tiy.Wins,
                Losses = tiy.Losses,
                Ties = tiy.Ties,
                LikelyWins = tiy.LikelyWins,
                LikelyLosses = tiy.LikelyLosses,
                LikelyTies = tiy.LikelyTies,
                ByeId = tiy.ByeId
            }).ToList();

            return CreatedAtAction("GetTeamsInSpecificYear", new { yearId = teams.First().YearId }, newDtos);
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

        [HttpPut("teaminyears/many")]
        public async Task<ActionResult<IEnumerable<TeamInYear>>> PutManyTeamInYear(IEnumerable<TeamInYearDto> dtos)
        {
            foreach (var dto in dtos)
            {
                var team = await _context.TeamsInYears.FindAsync(dto.Id);
                if (team is null)
                {
                    return NotFound();
                }

                team.TeamId = dto.TeamId;
                team.YearId = dto.YearId;
                team.OfRating = dto.OfRating;
                team.DfRating = dto.DfRating;
                team.Wins = dto.Wins;
                team.Losses = dto.Losses;
                team.Ties = dto.Ties;
                team.LikelyWins = dto.LikelyWins;
                team.LikelyLosses = dto.LikelyLosses;
                team.LikelyTies = dto.LikelyTies;
                team.ByeId = dto.ByeId;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
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
        public async Task<ActionResult<Week>> PostWeek(WeekDto dto)
        {
            Week week = await _dbService.WeekDtoConversion(dto);
            _context.Weeks.Add(week);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeek", new { id = week.Id }, week);
        }

        [HttpPost("weeks/many")]
        public async Task<ActionResult<IEnumerable<Week>>> PostWeeks(IEnumerable<WeekDto> dtos)
        {
            List<Week> weeks = new List<Week>();
            foreach (WeekDto dto in dtos)
            {
                Week week = await _dbService.WeekDtoConversion(dto);
                weeks.Add(week);
            }
            _context.Weeks.AddRange(weeks);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWeek", new { id = weeks[0].Id }, weeks);
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

        [HttpGet("years/{id}/full")]
        public async Task<ActionResult<Year>> GetYearFull(int id)
        {
            var year = await _context.Years
                .Include(year => year.Weeks)
                .ThenInclude(week => week.Games)
                //.Include(year => year.TeamInYears)
                //.AsSplitQuery()
                .Where(year => year.Id == id)
                .FirstAsync();
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

        [HttpGet("createyear/teams")]
        public async Task<ActionResult<IEnumerable<TeamDtoCreateYear>>> CreateYearGetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams.Select(team => new TeamDtoCreateYear(team.Id, team.Name)).ToList();
        }

        [HttpPost("createyear/years")]
        public async Task<ActionResult<YearDtoCreateWeeks>> CreateYearPostYear(YearDtoCreateYear dto)
        {
            var year = new Year()
            {
                YearNo = dto.YearNo,
            };
            _context.Years.Add(year);
            await _context.SaveChangesAsync();

            var returnDto = new YearDtoCreateWeeks(year.Id, year.YearNo);

            return CreatedAtAction("GetYear", new { id = year.Id }, returnDto);
        }

        [HttpPost("createyear/teaminyears")]
        public async Task<ActionResult<IEnumerable<TiyDtoCreateWeeksGet>>> CreateYearPostTeamInYears(IEnumerable<TiyDtoCreateYear> dtos)
        {
            var tiys = new List<TeamInYear>();
            foreach (var dto in dtos)
            {
                var team = await _context.Teams.FindAsync(dto.TeamId);
                if (team is null)
                {
                    return NotFound();
                }

                var tiy = new TeamInYear()
                {
                    TeamId = dto.TeamId,
                    Team = team,
                    YearId = dto.YearId,
                    OfRating = dto.OfRating,
                    DfRating = dto.DfRating,
                    // int default value is 0, wins/losses/etc. will all get that
                };

                tiys.Add(tiy);
            }

            _context.TeamsInYears.AddRange(tiys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamInYear", new { id = tiys[0].Id },
                tiys.Select(tiy => new TiyDtoCreateWeeksGet(tiy.Id, tiy.TeamId, tiy.Team.Code, tiy.Team.Name)).ToList());
        }

        // currently making weeks one at a time, then getting their ids to feed to the list of games on the front end.
        //[HttpPost("createweeks/weeks")]
        //public async Task<ActionResult<int>> CreateWeeksPostWeek(WeekDtoCreateWeeks dto)
        //{
        //    var year = await _context.Years.FindAsync(dto.YearId);
        //    if (year is null)
        //    {
        //        return NotFound();
        //    }

        //    var week = new Week()
        //    {
        //        WeekNo = dto.WeekNo,
        //        YearId = dto.YearId,
        //        Year = year,
        //        PlayoffPicture = new PlayoffPicture { }
        //    };

        //    _context.Weeks.Add(week);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetWeek", new { id = week.Id }, week.Id);
        //}

        [HttpPost("createweeks/weeks")]
        public async Task<ActionResult<IEnumerable<WeekDtoCreateWeeks>>> CreateWeeksPostWeeks(IEnumerable<WeekDtoCreateWeeks> dtos)
        {
            var year = await _context.Years
                .Include(year => year.TeamInYears)
                .FirstAsync(year => year.Id == dtos.First().YearId);
            if (year is null)
            {
                return NotFound();
            }

            var weeks = new List<Week>();
            foreach (var weekDto in dtos)
            {

                var week = new Week
                {
                    WeekNo = weekDto.WeekNo,
                    YearId = weekDto.YearId,
                    Year = year,
                    Games = weekDto.Games.Select(gameDto =>
                    {
                        Game game = new Game
                        {
                            GameType = gameDto.GameType,
                            AwayTeamId = gameDto.AwayTeamId,
                            AwayTeam = year.TeamInYears.First(team => team.Id == gameDto.AwayTeamId),
                            HomeTeamId = gameDto.HomeTeamId,
                            HomeTeam = year.TeamInYears.First(team => team.Id == gameDto.HomeTeamId),
                        };

                        // adjust expected record for each team in a game
                        if (game.AwayTeam.AvRating() > game.HomeTeam.AvRating())
                        {
                            game.AwayTeam.LikelyWins += 1;
                            game.HomeTeam.LikelyLosses += 1;
                        }
                        else if (game.AwayTeam.AvRating() < game.HomeTeam.AvRating())
                        {
                            game.AwayTeam.LikelyLosses += 1;
                            game.HomeTeam.LikelyWins += 1;
                        }
                        else
                        {
                            game.AwayTeam.LikelyTies += 1;
                            game.HomeTeam.LikelyTies += 1;
                        }

                        return game;
                    }).ToList()
                };
                // assign byes to teams who don't have games this week
                // if there are less than 16 games in a week, that means there are byes that we want to assign
                if (week.Games.Count < 16)
                {
                    foreach (var team in year.TeamInYears)
                    {
                        // if the team already has a bye, don't check
                        if (team.Bye is not null) continue;
                        foreach (var game in week.Games)
                        {
                            // if a game has the team as either the home or away team, we know they won't have a bye this week
                            if (team.Id == game.AwayTeamId || team.Id == game.HomeTeamId)
                            {
                                break;
                            }

                            // if this was the last game of the week, and we still haven't found anything, then this is the team's bye week
                            if (week.Games.Last().AwayTeamId == game.AwayTeamId)
                            {
                                team.Bye = week;
                            }
                        }
                    }
                }
                weeks.Add(week);
            }

            _context.Weeks.AddRange(weeks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeek", new { id = weeks[0].Id }, dtos);
        }

        //[HttpPost("createweeks/games")]
        //public async Task<ActionResult<IEnumerable<GameDtoCreateWeeks>>> CreateWeeksPostGames(IEnumerable<GameDtoCreateWeeks> dtos)
        //{
        //    var games = new List<Game>();
        //    foreach (var dto in dtos)
        //    {
        //        var awayTeam = await _context.TeamsInYears.FindAsync(dto.AwayTeamId);
        //        var homeTeam = await _context.TeamsInYears.FindAsync(dto.HomeTeamId);
        //        if (awayTeam is null || homeTeam is null)
        //        {
        //            return NotFound();
        //        }

        //        var game = new Game()
        //        {
        //            GameType = dto.GameType,
        //            WeekId = dto.WeekId,
        //            AwayTeamId = dto.AwayTeamId,
        //            AwayTeam = awayTeam,
        //            HomeTeamId = dto.HomeTeamId,
        //            HomeTeam = homeTeam,
        //        };

        //        games.Add(game);
        //    }

        //    _context.Games.AddRange(games);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = games[0].Id }, dtos);
        //}

        //[HttpPut("createweeks/teaminyears")]
        //public async Task<ActionResult<IEnumerable<TiyDtoCreateWeeksPut>>> CreateWeeksPutTeamInYears(IEnumerable<TiyDtoCreateWeeksPut> dtos)
        //{
        //    foreach (var dto in dtos)
        //    {
        //        var tiy = await _context.TeamsInYears.FindAsync(dto.Id);
        //        if (tiy is null)
        //        {
        //            return NotFound();
        //        }

        //        tiy.ByeId = dto.ByeId;
        //    }

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
        //    }
        //    return NoContent();
        //}

        //private async Task CalculateLikelyRecords(int id)
        //{
        //    var year = await _context.Years
        //        .Include(year => year.Weeks)
        //        .ThenInclude(week => week.Games)
        //        .Include(year => year.TeamInYears)
        //        .FirstAsync(year => year.Id == id);
        //    foreach (var week in year.Weeks)
        //    {
        //        foreach (var game in week.Games)
        //        {
        //            if (game.AwayTeam.AvRating() > game.HomeTeam.AvRating())
        //            {
        //                game.AwayTeam.LikelyWins += 1;
        //                game.HomeTeam.LikelyLosses += 1;
        //            }
        //            else if (game.AwayTeam.AvRating() < game.HomeTeam.AvRating())
        //            {
        //                game.AwayTeam.LikelyLosses += 1;
        //                game.HomeTeam.LikelyWins += 1;
        //            }
        //            else
        //            {
        //                game.AwayTeam.LikelyTies += 1;
        //                game.HomeTeam.LikelyTies += 1;
        //            }
        //        }
        //    }
        //    await _context.SaveChangesAsync();
        //}

        //[HttpPost("createweeks/likelyrecord/year/{id}")]
        //public async Task<ActionResult<bool>> CalcRecords(int id)
        //{
        //    await CalculateLikelyRecords(id);
        //    return Ok(true);
        //}

        [HttpGet("viewyear/years/{id}")]
        public async Task<ActionResult<YearDtoViewYear>> ViewYearGetYear(int id)
        {
            var year = await _context.Years
                .Include(year => year.Weeks)
                .ThenInclude(week => week.Games)
                .Include(year => year.Weeks)
                .ThenInclude(week => week.PlayoffStandings)
                .Include(year => year.TeamInYears)
                .ThenInclude(tiy => tiy.Team)
                .FirstAsync(year => year.Id == id);
            if (year is null)
            {
                return NotFound();
            }

            var weeks = year.Weeks.Select(week => new WeekDtoViewYear
            (
                week.Id,
                week.WeekNo,
                week.Games.Select(game => new GameDtoViewYearGet(game.Id, week.Id, game.AwayTeamId, game.HomeTeamId, game.AwayTeamScore, game.HomeTeamScore)).ToList(),
                week.PlayoffStandings.Select(standing => new PlayoffStandingDtoViewYearGetPut(standing.Id, standing.WeekId, standing.TeamInYearId, standing.Conference, standing.Seed, standing.Record, standing.Change)).ToList()
                )

            ).ToList();
            var teams = year.TeamInYears.Select(team => new TiyDtoViewYear(team.Id, team.Team.Name, team.Team.Conference, team.Team.Division, team.OfRating, team.DfRating, team.Wins, team.Losses, team.Ties, team.LikelyWins, team.LikelyLosses, team.LikelyTies, team.ByeId ?? 0, team.Seed, team.Result)).ToList();
            var returnYear = new YearDtoViewYear(id, year.YearNo, weeks, teams);

            return returnYear;
        }

        // UNDER CONSTRUCTION
        [HttpGet("/viewweek/weeks/{id}")]
        public async Task<ActionResult<WeekDtoViewWeek>> ViewWeekGetWeek(int id)
        {
            var week = await _context.Weeks
                .Include(week => week.PlayoffStandings)
                .Include(week => week.Games)
                .FirstAsync(week => week.Id == id);

            return new WeekDtoViewWeek();
        }
    }
}
