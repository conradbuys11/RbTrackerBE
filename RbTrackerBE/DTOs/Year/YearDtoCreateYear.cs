namespace RbTrackerBE.DTOs.Year
{
    /// <summary>
    /// Used to POST a new year. From CreateYear page.
    /// </summary>
    public class YearDtoCreateYear
    {
        public int YearNo { get; set; }

        public YearDtoCreateYear(int yearNo)
        {
            YearNo = yearNo;
        }
    }
}
