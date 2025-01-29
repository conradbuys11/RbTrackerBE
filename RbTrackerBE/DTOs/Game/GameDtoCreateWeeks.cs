using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs.Game
{
    /// <summary>
    /// Used to POST a new game. From CreateWeeks page.
    /// </summary>
    public class GameDtoCreateWeeks
    {
        public GameType GameType { get; set; }
        public int WeekId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }

        public GameDtoCreateWeeks(GameType gameType, int weekId, int awayTeamId, int homeTeamId)
        {
            GameType = gameType;
            WeekId = weekId;
            AwayTeamId = awayTeamId;
            HomeTeamId = homeTeamId;
        }
    }
}
