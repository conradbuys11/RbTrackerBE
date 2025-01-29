namespace RbTrackerBE.DTOs.Game
{
    /// <summary>
    /// Used to GET a game. From ViewYear page.
    /// </summary>
    public class GameDtoViewYearGet
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }

        public GameDtoViewYearGet(int id, int weekId, int awayTeamId, int homeTeamId, int? awayTeamScore, int? homeTeamScore)
        {
            Id = id;
            WeekId = weekId;
            AwayTeamId = awayTeamId;
            HomeTeamId = homeTeamId;
            AwayTeamScore = awayTeamScore;
            HomeTeamScore = homeTeamScore;
        }
    }
}
