using RbTrackerBE.DTOs.Game;

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

        public WeekDtoViewYear(int id, int weekNo, ICollection<GameDtoViewYearGet> games)
        {
            Id = id;
            WeekNo = weekNo;
            Games = games;
        }
    }
}
