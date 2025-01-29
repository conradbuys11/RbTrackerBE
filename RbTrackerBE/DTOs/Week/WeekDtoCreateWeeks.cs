namespace RbTrackerBE.DTOs.Week
{
    /// <summary>
    /// Used to POST a new week. From CreateWeeks page.
    /// </summary>
    public class WeekDtoCreateWeeks
    {
        public int WeekNo { get; set; }
        public int YearId { get; set; }

        public WeekDtoCreateWeeks(int weekNo, int yearId)
        {
            WeekNo = weekNo;
            YearId = yearId;
        }
    }
}
