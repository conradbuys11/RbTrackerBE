using RbTrackerBE.DTOs.TeamInYear;
using RbTrackerBE.DTOs.Week;

namespace RbTrackerBE.DTOs.Year
{
    /// <summary>
    /// Used to GET a year. From ViewYear page.
    /// </summary>
    public class YearDtoViewYear
    {
        public int YearNo { get; set; }
        public ICollection<WeekDtoViewYear> Weeks { get; set; }
        public ICollection<TiyDtoViewYear> Teams { get; set; }

        public YearDtoViewYear(int yearNo, ICollection<WeekDtoViewYear> weeks, ICollection<TiyDtoViewYear> teams)
        {
            YearNo = yearNo;
            Weeks = weeks;
            Teams = teams;
        }
    }
}
