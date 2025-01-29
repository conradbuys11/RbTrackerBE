namespace RbTrackerBE.DTOs.Year
{
    /// <summary>
    /// Used to GET a year. From CreateWeeks page.
    /// </summary>
    public class YearDtoCreateWeeks
    {
        public int Id { get; set; }
        public int YearNo { get; set; }

        public YearDtoCreateWeeks(int id, int yearNo)
        {
            Id = id;
            YearNo = yearNo;
        }
    }
}
