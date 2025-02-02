using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs.PlayoffStanding
{
    public class PlayoffStandingDtoViewYearPost
    {
        public int WeekId { get; set; }
        public int TeamInYearId { get; set; }
        public Conference Conference { get; set; }
        public int Seed { get; set; }

        public PlayoffStandingDtoViewYearPost(int weekId, int tiyId, Conference conference, int seed)
        {
            WeekId = weekId;
            TeamInYearId = tiyId;
            Conference = conference;
            Seed = seed;
        }
    }
}
