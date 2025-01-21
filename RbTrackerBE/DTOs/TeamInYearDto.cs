namespace RbTrackerBE.DTOs
{
    public class TeamInYearDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int YearId { get; set; }
        public float OfRating { get; set; }
        public float DfRating { get; set; }
        // public float AvRating { get; set; } should be a function
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        // public string Record { get; set; } should be a function
        public int LikelyWins { get; set; }
        public int LikelyLosses { get; set; }
        public int LikelyTies { get; set; }
        // public string LikelyRecord { get; set; } should be a function
        public int? ByeId { get; set; }
    }
}
