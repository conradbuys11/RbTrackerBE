using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public GameType GameType { get; set; }
        public int WeekId { get; set; }
        public Week Week { get; set; } = null!;
        public int AwayTeamId { get; set; }
        public TeamInYear AwayTeam { get; set; } = null!;
        public int HomeTeamId { get; set; }
        public TeamInYear HomeTeam { get; set; } = null!;
        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }
    }
}
