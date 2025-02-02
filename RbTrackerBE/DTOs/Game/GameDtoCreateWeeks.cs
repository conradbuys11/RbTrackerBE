using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs.Game
{
    /// <summary>
    /// Used to POST a new game. From CreateWeeks page.
    /// </summary>
    public class GameDtoCreateWeeks
    {
        // Gid is used on the front end but not at all in the back end. just included to make the DTOs match
        public string? Gid { get; set; }
        public GameType GameType { get; set; }
        public int WeekId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }

        public GameDtoCreateWeeks(GameType gameType, int weekId, int awayTeamId, int homeTeamId, string? gid)
        {
            GameType = gameType;
            WeekId = weekId;
            AwayTeamId = awayTeamId;
            HomeTeamId = homeTeamId;
            Gid = gid;
        }
    }
}
