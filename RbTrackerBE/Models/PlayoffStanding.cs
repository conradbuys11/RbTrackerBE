using RbTrackerBE.Enums;
using System.ComponentModel.DataAnnotations;

namespace RbTrackerBE.Models
{
    public class PlayoffStanding
    {
        [Key]
        public int Id { get; set; }

        public int WeekId { get; set; }
        public Week Week { get; set; } = null!;
        public int TeamInYearId { get; set; }
        public TeamInYear TeamInYear { get; set; } = null!;
        public Conference Conference { get; set; }
        public int Seed { get; set; }
        // teaminyear's record for this week
        public string Record { get; set; } = null!;
        // change of seed for this teaminyear from last week
        public SeedChange Change { get; set; }
    }
}
