namespace RbTrackerBE.DTOs.TeamInYear
{
    /// <summary>
    /// Used to GET a TeamInYear. From CreateWeeks page.
    /// </summary>
    public class TiyDtoCreateWeeksGet
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }

        public TiyDtoCreateWeeksGet(int id, int teamId, string teamCode, string teamName)
        {
            Id = id;
            TeamId = teamId;
            TeamCode = teamCode;
            TeamName = teamName;
        }
    }
}
