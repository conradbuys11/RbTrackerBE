using RbTrackerBE.DTOs.Game;
using RbTrackerBE.DTOs.PlayoffStanding;

namespace RbTrackerBE.DTOs.Week
{
    /// <summary>
    /// Used to GET a week. From ViewYear page.
    /// </summary>
    public class WeekDtoViewYear
    {
        public int Id { get; set; }
        public int WeekNo { get; set; }
        public ICollection<GameDtoViewYearGet> Games { get; set; }
        public ICollection<PlayoffStandingDtoViewYearGetPut> Standings { get; set; }

        public WeekDtoViewYear(int id, int weekNo, ICollection<GameDtoViewYearGet> games, ICollection<PlayoffStandingDtoViewYearGetPut> standings)
        {
            Id = id;
            WeekNo = weekNo;
            Games = games;
            Standings = standings;
        }
    }
}
