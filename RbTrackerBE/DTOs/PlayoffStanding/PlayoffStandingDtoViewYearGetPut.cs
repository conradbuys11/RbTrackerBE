using RbTrackerBE.Enums;

namespace RbTrackerBE.DTOs.PlayoffStanding
{
    public class PlayoffStandingDtoViewYearGetPut
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int TeamInYearId { get; set; }
        public Conference Conference { get; set; }
        public int Seed { get; set; }
        public string Record { get; set; }
        public SeedChange Change { get; set; }

        public PlayoffStandingDtoViewYearGetPut(int id, int weekId, int tiyId, Conference conference, int seed, string record, SeedChange change)
        {
            Id = id;
            WeekId = weekId;
            TeamInYearId = tiyId;
            Conference = conference;
            Seed = seed;
            Record = record;
            Change = change;
        }
    }
}
