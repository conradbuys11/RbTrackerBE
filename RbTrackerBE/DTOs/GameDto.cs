using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public GameType GameType { get; set; }
        public int WeekId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }
    }
}
