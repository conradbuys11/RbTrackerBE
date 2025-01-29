namespace RbTrackerBE.DTOs.TeamInYear
{
    /// <summary>
    /// Used to POST a new TeamInYear. From CreateYear page.
    /// </summary>
    public class TiyDtoCreateYear
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int YearId { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }

        public TiyDtoCreateYear(int teamId, string teamName, int yearId, float ofRating, float dfRating)
        {
            TeamId = teamId;
            TeamName = teamName;
            YearId = yearId;
            OfRating = ofRating;
            DfRating = dfRating;
        }
    }
}
